using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace ServerChessGame
{
    internal class Program
    {
        private static TcpListener server = null;
        private static TcpClient client = null;
        private static Thread manageClientThread = null;
        private static Hashtable clients = new Hashtable(); //chứa danh sách client
        private static Hashtable manageChatThread = new Hashtable();
        private static Thread acceptClientThread = null;
        private static NetworkStream stream = null;
        private static byte[] key = new byte[]
        {
            0x54, 0x68, 0x69, 0x73, 0x49, 0x73, 0x54, 0x68, 0x65, 0x46, 0x69, 0x78, 0x65, 0x64, 0x4B, 0x65, // 16-byte key
            0x79, 0x31, 0x32, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // Padding bytes
        };

        private static byte[] iv = new byte[]
        {
             0x54, 0x68, 0x69, 0x73, 0x49, 0x73, 0x54, 0x68, 0x65, 0x46, 0x69, 0x78, 0x65, 0x64, 0x49, 0x56  // 16-byte IV
        };
        public static void sendDataForAllClientExceptionSender(string userName, string message)
        {
            if(clients != null)
            {
                foreach (string item in clients.Keys)
                {
                    if (item != userName)
                    {
                        TcpClient cl = (TcpClient)clients[item];
                        if (cl != null)
                        {
                            stream = cl.GetStream();
                            byte[] buffer2 = Encoding.UTF8.GetBytes(message);
                            stream.Write(buffer2, 0, buffer2.Length);
                        }
                    }
                }
            }
        }
        public static void sendDataForClient(string userName, string message)
        {
            TcpClient cl = (TcpClient)clients[userName];
            if (cl != null)
            {
                stream = cl.GetStream();
                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer1, 0, buffer1.Length);
            }
        }
        public static void sendDataForAllClients(string message)
        {
            foreach (string key in clients.Keys)
            {
                TcpClient cl = (TcpClient)clients[key];
                stream = cl.GetStream();
                byte[] buffer2 = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer2, 0, buffer2.Length);
            }
        }
        private static string DecryptMessage(string encryptedMessage)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);

                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        public static string EncryptMessage(string message)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(message);
                        }
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }
        static void acceptClient()
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                //khi login vào
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024 * 500];
                int length = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, length);
                string decryptData = DecryptMessage(message);
                string[] lst = decryptData.Split('*');
                string userName = lst[1];

                if (clients.ContainsKey(userName))
                {
                    clients.Remove(userName);
                }
                clients.Add(userName, client);

                //phân phối tin nhắn về cho các client còn lại
                sendDataForAllClientExceptionSender(userName, EncryptMessage(decryptData));

                //khởi chạy toàn bộ luồng dữ liệu
                manageClientThread = new Thread(new ParameterizedThreadStart(rcvData));
                if (manageChatThread.ContainsKey(userName))
                {
                    manageChatThread.Remove(userName);
                }
                manageChatThread.Add(userName, manageClientThread);

                Thread thread = (Thread)manageChatThread[userName];
                thread.Start(client);
            }
        }
        static void rcvData(object cl)
        {
            try
            {
                TcpClient client = (TcpClient)cl;
                while (true)
                {
                    stream = client.GetStream();
                    byte[] buffer = new byte[1024 * 500];
                    int length = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, length);
                    string decryptData = DecryptMessage(message);
                    //phân loại dữ liệu
                    string[] listMsg = decryptData.Split('*');

                    switch (int.Parse(listMsg[0]))
                    {
                        case 0: //cập nhật lại danh sách phòng chơi
                            sendDataForAllClientExceptionSender(listMsg[1], message);
                            break;
                        case 1:
                            string[] lst = listMsg[1].Split('+');
                            sendDataForClient(lst[0], message);
                            break;
                        case 2:
                            sendDataForClient(listMsg[1].Split('+')[0], message);
                            break;
                        case 3:
                            sendDataForAllClients(message);
                            break;
                        case 4: //dùng để tạo ra các luồng chat 1-1
                            string[] lstInfo = listMsg[1].Split(":");
                            sendDataForClient(lstInfo[3], message);

                            break;
                        case 5:
                            //tách lấy ra username
                            string[] strs = listMsg[1].Split(":");
                            string userName = strs[0].Substring(0, strs[0].Length - 3);
                            //tiến hành gửi dữ liệu về cho những user còn lại
                            sendDataForAllClientExceptionSender(userName, message);
                            break;
                        case 6: //xử lý logout
                            string[] msgs = listMsg[1].Split(",");
                            //gửi dữ liệu đến các client còn lại
                            sendDataForAllClientExceptionSender(msgs[0], message);
                            //đóng kết nối của client này
                            TcpClient currentCl1 = (TcpClient)clients[msgs[0]];
                            if (currentCl1 != null)
                                currentCl1.Close();
                            clients.Remove(msgs[0]);
                            foreach (string key in manageChatThread.Keys)
                            {
                                if (key == msgs[0])
                                {
                                    manageChatThread.Remove(key);
                                    return;
                                }
                            }
                            break;
                        case 7:
                            string[] lst1 = listMsg[1].Split(':');
                            sendDataForClient(lst1[0], message);
                            break;
                        case 8:

                            //lay ra tcpClient cua nguoi choi nay
                            string[] lst2 = listMsg[1].Split("+");
                            string username = lst2[1];
                            string preUsername = lst2[0];
                            if (!string.Equals(username, preUsername))
                            {
                                TcpClient currentTcpClient = (TcpClient)clients[preUsername];
                                clients.Remove(preUsername);
                                clients.Add(username, currentTcpClient);

                                Thread currentThread = (Thread)manageChatThread[preUsername];
                                manageChatThread.Remove(preUsername);
                                manageChatThread.Add(username, currentThread);

                                sendDataForAllClients(message);
                            }
                            else
                            {
                                sendDataForClient(preUsername, message);
                            }
                            break;
                        case 10:
                            sendDataForClient(listMsg[1].Split('+')[0], message);
                            break;

                        case 11:
                            sendDataForAllClients(message);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        static void Main(string[] args)
        {
            server = new TcpListener(System.Net.IPAddress.Any, 8081);
            server.Start();


            acceptClientThread = new Thread(new ThreadStart(acceptClient));
            acceptClientThread.Start();
        }
    }
}