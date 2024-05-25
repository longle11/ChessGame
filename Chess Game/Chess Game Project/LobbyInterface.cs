using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.UI;
using Guna.UI2.WinForms;
using System.Runtime.Remoting.Contexts;
using Chess_Game_Project.classes_handle;
using System.Xml.Linq;
using Chess_Game_Project.manageUsers;
using System.Text.RegularExpressions;
using Chess_Game_Project.CryptoGraphy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Reflection;

namespace Chess_Game_Project
{
    public partial class LobbyInterface : Form
    {
        #region apiPath
        private string apiGetListMatches = "https://chessmates.onrender.com/api/v1/matches";
        private string apiCreateRoom = "https://chessmates.onrender.com/api/v1/matches/add";
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string apiGetAllUser = "https://chessmates.onrender.com/api/v1/users";
        private string apiGetUserId = "https://chessmates.onrender.com/api/v1/users/";
        private string apiMakeFriend = "https://chessmates.onrender.com/api/v1/listFriends/add";
        private string apiGetAllListFriend = "https://chessmates.onrender.com/api/v1/listFriends";
        private string apiUpdaStatusFriend = "https://chessmates.onrender.com/api/v1/listFriends/edit/";
        private string apiDeleteFriend = "https://chessmates.onrender.com/api/v1/listFriends/delete/";
        private string apiAddUserIntoMatch = "https://chessmates.onrender.com/api/v1/matches/edit/addOrSubUser/";
        #endregion

        #region infoUser
        private infoUser user;
        private string linkAvatar;
        private string ipAddress = "192.168.95.136";
        private string myIpAddress = "";
        private string difUsernameUser = "";
        #endregion

        #region variables
        public static LobbyInterface showInter = null;
        private string parentDirectory;
        private TcpClient client = null;

        private Thread rcvDataThread = null;
        private userControlChatOne chat = null;
        public static int posY = 0;
        public int countMsg = 0;


        userControlLists userControlLists = null;
        userControlHistory history = null;
        userControlRanks rank = null;
        userControlCreateRoom createRoom = null;
        #endregion

        //============================================  CÁC HÀM XỬ LÝ RIÊNG BIỆT =========================================================
        private async void LobbyInterface_Load(object sender, EventArgs e)
        {
            try
            {
                handleLoadInterface.loadInterFace(this, pnlCoverPage, pnlContent);
                ptbAvatarPage.Size = this.Size;
                ptbAvatarPage.BackgroundImage = System.Drawing.Image.FromFile("Resources\\lobbyImage.jpg");
                ptbAvatarPage.BackgroundImageLayout = ImageLayout.Stretch;
                pnlContent.Parent = ptbAvatarPage;

                pnlContent.BringToFront();

                if (!string.IsNullOrEmpty(user.linkAvatar))
                {
                    user.linkAvatar = "defaultAvatar.jpg";
                    ptboxAvatar.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
                    ptboxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                pnlContainsIcon.Parent = pnlMultiChats;
                pnlMultiChatFrame.Parent = pnlMultiChats;
                pnlContainsIcon.BringToFront();


                pnlCoverPage.BringToFront();

                await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
                List<infoUser> getFriends = await handleGetLists.getListUser("waiting", user, apiGetUserId);
                hanleDataIntoDatagridview.displayListWaitingAccept(getFriends, userControlLists);
                await handleGetLists.getListAllUser(user.id, apiGetAllUser, userControlLists, user);

                getFriends = await handleGetLists.getListUser("friend", user, apiGetUserId);
                hanleDataIntoDatagridview.displayListFriends(getFriends, userControlLists);

                //tạo ra luồng chat giữa các client 
                await createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);
            }
            catch (Exception ex)
            {

            }
        }
        private void calLocationChildPanel(System.Windows.Forms.Panel parent, System.Windows.Forms.UserControl child)
        {
            // Tính toán vị trí để đặt Panel con vào giữa Panel cha
            int childX = (parent.Width - child.Width) / 2;
            int childY = (parent.Height - child.Height) / 2;


            // Đặt Anchor để Panel con giữa trung tâm Panel cha khi Panel cha thay đổi kích thước
            child.Anchor = AnchorStyles.None;
            parent.Dock = DockStyle.Fill;
            child.BringToFront();
            // Đặt vị trí cho Panel con
            child.Location = new Point(childX, childY);
            parent.Controls.Add(child);
        }
        private async Task handleLogOutRoom()
        {
            try
            {
                apiGetUser += user.id;
                posY = 0;
                //cập nhật trạng thái thành offline
                var data = new
                {
                    userName = user.userName,
                    gmail = user.gmail,
                    linkAvatar = user.linkAvatar == "defaultAvatar.jpg" ? "defaultAvatar.jpg" : user.linkAvatar,
                    statusActive = "offline",
                };
                JToken tkData = await manageApi.callApiUsingMethodPut(data, apiGetUser);
                if (tkData != null)
                {
                    //gửi thông điệp logout lên server
                    string message = (int)manageChooseCases.setting.logout + "*" + user.userName + "," + user.id;
                    handleChat.sendData(client, message);

                    client = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void loopChildPanel(System.Windows.Forms.UserControl child)
        {
            foreach (System.Windows.Forms.UserControl childControl in pnlContainsChild.Controls.OfType<System.Windows.Forms.UserControl>())
            {
                if (childControl == child)
                {
                    pnlContainsChild.Show();
                    childControl.Show();
                }
                else
                {
                    childControl.Hide();
                }
            }
        }
        private static NetworkInterface GetWifiInterface()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in interfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    return networkInterface;
                }
            }

            return null;
        }
        private static IPAddress GetWifiIPv4Address(NetworkInterface wifiInterface)
        {
            IPInterfaceProperties properties = wifiInterface.GetIPProperties();

            foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
            {
                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.Address;
                }
            }

            return null;
        }

        private void deleteFrameChat(string difUserName, string notify)
        {
            Action myAction = () =>
            {
                //tiến hành xóa đi phòng chat của user này 
                foreach (userControlChatOne control in createChatOneFrame.listChats)
                {
                    if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(difUserName))
                    {
                        if (control.Visible)
                        {
                            MessageBox.Show(notify);
                        }
                        control.Hide();
                        pnlChatOne.Hide();
                        createChatOneFrame.listChats.Remove(control);
                        break;
                    }
                }
            };

            // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
            if (this.InvokeRequired)
                this.Invoke(myAction);
            else
                myAction();
        }

        private void deleteRoom(string idMatch)
        {
            foreach (DataGridViewRow row in dtGridContainListRooms.Rows)
            {
                if (string.Equals(row.Cells["id"].Value.ToString(), idMatch))
                {
                    dtGridContainListRooms.Rows.Remove(row);
                    break;
                }
            }
        }
        //=================================================================================================================================

        //============================================  HÀM KHỞI TẠO MẶC ĐỊNH =============================================================
        public LobbyInterface()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            dtGridContainListRooms.RowTemplate.Height = 45;

            int childX = (pnlCoverPage.Width - pnlContainsChild.Width) / 2;
            int childY = (pnlCoverPage.Height - pnlContainsChild.Height) / 2;
            pnlContainsChild.Location = new Point(childX, childY);

            pnlCoverPage.Controls.Add(pnlContainsChild);
            pnlContainsChild.BringToFront();

            pnlContainsChild.AutoSize = false;
            pnlContainsChild.Hide();
            pnlContainsChild.Anchor = AnchorStyles.None;
            pnlContainsChild.Dock = DockStyle.Fill;

            int childX1 = (pnlContainsChild.Width - pnlChatOne.Width) / 2;
            int childY1 = (pnlContainsChild.Height - pnlChatOne.Height) / 2;
            pnlChatOne.Anchor = AnchorStyles.None;
            pnlContainsChild.Dock = DockStyle.Fill;
            pnlChatOne.Location = new Point(childX1, childY1);

            pnlContainsChild.Controls.Add(pnlChatOne);
            pnlChatOne.Hide();
            pnlChatOne.BringToFront();


            userControlLists = new userControlLists();
            userControlLists.btnCloseList_click += UserControlLists_btnCloseList_click;
            userControlLists.dtAcceptFriend_cellContentClick += UserControlLists_dtAcceptFriend_cellContentClick1;
            userControlLists.dtAllUsers_cellContentClick += UserControlLists_dtAllUsers_cellContentClick1;
            userControlLists.dtListFriends_cellContentClick += UserControlLists_dtListFriends_cellContentClick1;
            userControlLists.btnFindUser_click += UserControlLists_btnFindUser_click;
            userControlLists.btnLoadListAcceptFriends_click += UserControlLists_btnLoadListAcceptFriends_click;
            userControlLists.btnLoadListAllUsers_click += UserControlLists_btnLoadListAllUsers_click;
            userControlLists.btnLoadListFriends_click += UserControlLists_btnLoadListFriends_click;
            history = new userControlHistory();
            history.btnCloseHistory_click += History_btnCloseHistory_click;
            history.btnLoadListHistory_click += History_btnLoadListHistory_click;
            rank = new userControlRanks();
            rank.btnCloseRank_click += Rank_btnCloseRank_click;
            rank.btnLoadListRank_click += Rank_btnLoadListRank_click;
            createRoom = new userControlCreateRoom();
            createRoom.btnCloseCreateRoom_click += CreateRoom_btnCloseCreateRoom_click;
            createRoom.btnAcceptCreateRoom_click += CreateRoom_btnAcceptCreateRoom_click;
            calLocationChildPanel(pnlContainsChild, userControlLists);
            calLocationChildPanel(pnlContainsChild, rank);
            calLocationChildPanel(pnlContainsChild, history);
            calLocationChildPanel(pnlContainsChild, createRoom);

            pnlContainsIcon.Hide();


            pnlMultiChatFrame.AutoScroll = true;
        }
        public LobbyInterface(infoUser user) : this()
        {
            try
            {
                ////lấy ra ipv4 bên trong máy
                NetworkInterface wifiInterface = GetWifiInterface();
                if (wifiInterface != null)
                {
                    IPAddress ipv4 = GetWifiIPv4Address(wifiInterface);

                    if (ipv4 != null)
                        this.myIpAddress = ipv4.ToString();
                }
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ipAddress), 8081);
                rcvDataThread = new Thread(new ThreadStart(rcvData));
                rcvDataThread.Start();

                parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
                this.user = user;
                txtUserName.Text = user.userName;
                txtScore.Text = user.point.ToString();
                ptboxAvatar.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                showInter = this;

                //gửi thông điệp login lên server
                string message = (int)manageChooseCases.setting.login + "*" + user.userName;
                handleChat.sendData(client, message);

            }
            catch (Exception ex)
            {
                handleLogOutRoom();
                MessageBox.Show("Không thể kết nối tới server, vui lòng kiểm tra lại mạng của bạn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Login.showFormAgain.Show();
            }

        }
        //=================================================================================================================================

        //============================================ CÁC HÀM DÙNG ĐỂ GỬI VÀ NHẬN DỮ LIỆU =================================================
        public async void rcvData()
        {
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = new byte[1024 * 500];
                    int length = stream.Read(data, 0, data.Length);
                    if (length == 0) return;
                    string message = Encoding.UTF8.GetString(data, 0, length);
                    string decryptData = encryptAndDecryptData.DecryptMessage(message);
                    string[] listMsg = decryptData.Split('*');
                    switch (int.Parse(listMsg[0]))
                    {
                        case 0:
                            //tiến hành cập nhật lại danh sách phòng chơi
                            await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
                            break;
                        case 1:
                            string[] lstAcceptFriend = listMsg[1].Split('+');

                            listFriends newPairOfAccept = JsonConvert.DeserializeObject<listFriends>(lstAcceptFriend[2]);

                            if (newPairOfAccept != null)
                            {
                                user.lists.Add(newPairOfAccept);
                                userControlLists.hideBtnMakeFriend(lstAcceptFriend[1]);

                                List<infoUser> lists = await handleGetLists.getListUser("waiting", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListWaitingAccept(lists, userControlLists);
                            }
                            break;
                        case 2:
                            string[] lstBecomeFriend = listMsg[1].Split('+');
                            string difUserID = lstBecomeFriend[1];
                            string difUsername1 = lstBecomeFriend[2];
                            if (!string.IsNullOrEmpty(difUserID))
                            {
                                listFriends temp = null;
                                if (user.lists != null)
                                {
                                    foreach (listFriends item in user.lists)
                                    {
                                        if (item.listID.Contains(user.id) && item.listID.Contains(difUserID))
                                        {
                                            temp = item;
                                            break;
                                        }
                                    }
                                }
                                if (temp != null)
                                {
                                    user.lists.Remove(temp);
                                    temp.status = "friend";
                                    user.lists.Add(temp);
                                }

                                List<infoUser> lists1 = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListFriends(lists1, userControlLists);

                                Action myAction = () =>
                                {
                                    if (userControlLists.checkExistsUsernameIntoDataListFriends(difUsername1))
                                    {
                                        userControlLists.changeTextStatusActiveOnline(difUsername1);
                                        chat = new userControlChatOne();
                                        chat.Hide();
                                        chat.Tag = $"{user.userName},{difUsername1}";
                                        chat.Dock = DockStyle.Bottom;
                                        createChatOneFrame.listChats.Add(chat);
                                    }
                                };


                                // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                if (this.InvokeRequired)
                                    this.Invoke(myAction);
                                else
                                    myAction();
                            }

                            break;
                        case 3:
                            if (string.Equals(user.userName, listMsg[1].Split('+')[0]))
                                player.players = 2;
                            else
                                deleteRoom(listMsg[1].Split('+')[1]);
                            break;
                        case 4:
                            //tiến hành lấy ra nội dung dạng "content, linkAvatar, difUsername"
                            string[] lstMsg = listMsg[1].Split(':');
                            string difUsername = lstMsg[0].Substring(0, lstMsg[0].Length - 3);
                            //tiến hành hiển thị button danh sách kiểu (1)
                            bool checkCount = true;
                            foreach (userControlChatOne userControlChatOne in createChatOneFrame.listChats)
                            {
                                if (userControlChatOne.Tag.ToString().Contains(user.userName) && userControlChatOne.Tag.ToString().Contains(difUsername))
                                {
                                    if (userControlChatOne.Visible)
                                    {
                                        checkCount = false;
                                        break;
                                    }
                                }
                            }
                            if (!checkCount)
                            {
                                btnListFriend.Text = "Danh sách bạn bè";
                                userControlLists.changeTextInButtonChat(difUsername, true);
                            }
                            else
                            {
                                btnListFriend.Text = "Danh sách bạn bè (*)";
                                userControlLists.changeTextInButtonChat(difUsername, false);
                            }
                            foreach (userControlChatOne userControlChatOne in createChatOneFrame.listChats)
                            {
                                if (userControlChatOne.Tag.ToString().Contains(user.userName) && userControlChatOne.Tag.ToString().Contains(difUsername))
                                {
                                    chat = userControlChatOne;
                                    if (listMsg[1].Contains("(1)"))
                                    {
                                        handleChat.writeData(null, lstMsg[2], lstMsg[1], 1, difUsername, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat, chat.containsIcon);
                                    }
                                    else
                                    {
                                        string imageData = lstMsg[1];
                                        byte[] convertedBytes = Convert.FromBase64String(imageData);
                                        // Chuyển đổi mảng byte thành hình ảnh
                                        using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                        {
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                            handleChat.writeData(image, lstMsg[2], "", 2, difUsername, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat, chat.containsIcon);
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        case 5:
                            string[] msg = listMsg[1].Split(':');
                            if (listMsg[1].Contains("(1)"))
                                handleChat.writeData(null, msg[2], msg[1], 1, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame, this, posY, user.userName, parentDirectory, null, pnlContainsIcon);
                            else
                            {
                                string imageData = msg[1];
                                byte[] convertedBytes = Convert.FromBase64String(imageData);
                                // Chuyển đổi mảng byte thành hình ảnh
                                using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                    handleChat.writeData(image, msg[2], "", 2, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame, this, posY, user.userName, parentDirectory, null, pnlContainsIcon);
                                }
                            }
                            break;
                        case 6: //xử lý log out
                                //lấy id nhận về 
                            string id = listMsg[1].Split(',')[1];
                            string username = listMsg[1].Split(',')[0];
                            //kiểm tra xem trong danh sách bạn bè xem có user này không
                            bool check = false;
                            foreach (listFriends item in user.lists)
                            {
                                if (string.Equals(item.status.ToLower(), "friend"))
                                {
                                    if (item.listID.Contains(id))
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                            }
                            if (check)
                            {
                                userControlLists.changeTextStatusActiveOffline(username);
                                deleteFrameChat(username, "Người dùng đã offline, không thể chat với người này");
                            }
                            break;
                        case 7:
                            //nhan duoc 1 chuoi va tien hanh lay ra id cua nguoi choi can xoa
                            string[] lstStr = listMsg[1].Split(':');
                            string difUserID1 = lstStr[2];
                            string difUserName1 = lstStr[1];
                            listFriends friend = null;
                            foreach (listFriends item in user.lists)
                            {
                                if (item.listID.Contains(user.id) && item.listID.Contains((difUserID1)))
                                {
                                    friend = item;
                                    break;
                                }
                            }
                            if (friend != null)
                            {
                                //tien hanh xoa khoi danh sach
                                user.lists.Remove(friend);
                                //hiển thị lại nút kết bạn
                                userControlLists.showBtnMakeFriend(lstStr[1]);

                                //hủy luồng chat với người chơi này
                                deleteFrameChat(difUserName1, "Người dùng đã hủy kết bạn với bạn, không thể chat với người này");

                                List<infoUser> lists2 = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListFriends(lists2, userControlLists);
                            }
                            break;
                        case 8:
                            string[] lst1 = listMsg[1].Split('+');
                            if (string.Equals(user.id, lst1[2])) //kiem tra xem neu chinh user do nhan duoc thong tin thi chi can thay the lai thong tin cu
                            {
                                string preUserName = lst1[0];
                                Action myAction2 = () =>
                                {
                                    txtUserName.Text = lst1[1];
                                    ptboxAvatar.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + lst1[3]);
                                    ptboxAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                                };

                                // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                if (this.InvokeRequired)
                                    this.Invoke(myAction2);
                                else
                                    myAction2();


                                user.userName = lst1[1];
                                user.linkAvatar = lst1[3];
                                user.gmail = lst1[4];

                                pnlMultiChatFrame.Controls.Clear();
                                posY = 0;

                                Action myAction = () =>
                                {
                                    foreach (userControlChatOne oldChat in createChatOneFrame.listChats)
                                    {
                                        if (oldChat.Tag.ToString().Contains(preUserName))
                                        {
                                            oldChat.pos = 0;
                                            oldChat.pnlChatOne.Controls.Clear();
                                            oldChat.Tag = oldChat.Tag.ToString().Replace(preUserName, user.userName);
                                        }
                                    }
                                };
                                // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                if (this.InvokeRequired)
                                    this.Invoke(myAction);
                                else
                                    myAction();
                            }
                            else //neu nhung client dang online khac nhan duoc thi se reload lai danh sach
                            {
                                userControlLists.changeUserNameIntoDataAcceptFriend(lst1[1], lst1[0]);
                                userControlLists.changeUserNameIntoDataAllUser(lst1[1], lst1[0]);
                                userControlLists.changeUserNameIntoDataListFriends(lst1[1], lst1[0]);
                                rank.changeUserNameIntoDataRank(lst1[1], lst1[0]);
                                history.changeUserNameIntoDataHistory(lst1[1], lst1[0]);

                                //thay doi lai luong chat voi ten moi
                                userControlChatOne newChat = null;
                                foreach (userControlChatOne item in createChatOneFrame.listChats)
                                {
                                    if (item.Tag.ToString().Contains(user.userName) && item.Tag.ToString().Contains(lst1[0]))
                                    {
                                        if(item.Visible)
                                        {
                                            item.Hide();
                                            pnlChatOne.Hide();
                                        }
                                        
                                        newChat = item;
        
                                        break;
                                    }
                                }
                                if (newChat != null)
                                {
                                    Action myAction = () =>
                                    {
                                        createChatOneFrame.listChats.Remove(newChat);
                                        newChat.pos = 0;
                                        newChat.pnlChatOne.Controls.Clear();
                                        newChat.Tag = newChat.Tag.ToString().Replace(lst1[0], lst1[1]);
                                        createChatOneFrame.listChats.Add(newChat);
                                    };

                                    // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                    if (this.InvokeRequired)
                                        this.Invoke(myAction);
                                    else
                                        myAction();
                                }
                            }
                            break;
                        case 9:
                            string difUsername2 = listMsg[1];
                            //kiểm tra xem trong datagridview danh sách bạn bè có chứa user này hay không
                            if (userControlLists.checkExistsUsernameIntoDataListFriends(difUsername2))
                            {
                                Action myAction = () =>
                                {
                                    userControlLists.changeTextStatusActiveOnline(difUsername2);
                                    chat = new userControlChatOne();
                                    chat.Hide();
                                    chat.Tag = $"{user.userName},{difUsername2}";
                                    chat.Dock = DockStyle.Bottom;
                                    createChatOneFrame.listChats.Add(chat);
                                };

                                // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                if (this.InvokeRequired)
                                    this.Invoke(myAction);
                                else
                                    myAction();
                            }
                            break;
                        case 10:    //xu ly ket thuc phong dau
                            string[] lstMsgRcv = listMsg[1].Split('+');
                            this.user = JsonConvert.DeserializeObject<infoUser>(lstMsgRcv[1]);
                            Action myAction1 = async () =>
                            {
                                txtScore.Text = user.point.ToString();
                                await handleReloadList.reloadListRanks(apiGetUserId, apiGetAllUser, user, rank);
                                await handleReloadList.reloadListHistories(apiGetUserId, user, history);
                            };

                            // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                            if (this.InvokeRequired)
                                this.Invoke(myAction1);
                            else
                                myAction1();
                            

                            deleteRoom(lstMsgRcv[2]);
                            break;
                        case 11:    //xoa phong choi nay khi chu phong thoat ra
                            deleteRoom(listMsg[1]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra trong việc truyền dữ liệu, vui lòng đăng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Login.showFormAgain.Show();
                await handleLogOutRoom();
                this.Close();
            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            handleChat.displayListIconsIntoInterface(pnlContainsIcon, 8);
            foreach (System.Windows.Forms.Button btnChat in handleChat.buttonListIcons)
                btnChat.Click += BtnChat_Click;
        }
        private void BtnChat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string path = btn.Text;

            //tiến hành gửi dữ liệu đi
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)manageChooseCases.setting.chatMulti + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + ":" + user.linkAvatar;
            handleChat.sendData(client, message);

            handleChat.writeData(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, pnlMultiChatFrame, this, posY, user.userName, parentDirectory, null, pnlContainsIcon);
        }
        private void Chat_btnSendMsgChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                if (chat.TextBox.Text != "")
                {
                    if (chat.TextBox.Text.Length < 100)
                    {
                        //tiến hành gửi dữ liệu đi
                        string message = (int)manageChooseCases.setting.chatOne + "*" + user.userName + "(1):" + chat.TextBox.Text.Trim() + ":" + user.linkAvatar + ":" + difUsernameUser;
                        if (chat.TextBox.Text.Contains(':'))
                        {
                            MessageBox.Show("Không được phép nhập kí tự \":\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            handleChat.sendData(client, message);
                            handleChat.writeData(null, user.linkAvatar, chat.TextBox.Text.Trim(), 1, user.userName, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat, chat.containsIcon);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chỉ được phép nhập tối đa 100 ký tự");
                    }
                    chat.TextBox.Clear();
                }
            }
        }
        private void BtnChatOne_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string path = btn.Text;


            //tiến hành gửi dữ liệu đi
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)manageChooseCases.setting.chatOne + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + ":" + user.linkAvatar + ":" + difUsernameUser;
            handleChat.sendData(client, message);

            handleChat.writeData(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat, chat.containsIcon);
            chat.containsIcon.Hide();
            chat.listIcons.Clear();
        }
        private void Chat_btnSendIconChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                handleChat.displayListIconsIntoInterface(chat.containsIcon, 5);
                foreach (System.Windows.Forms.Button btnChat in handleChat.buttonListIcons)
                    btnChat.Click += BtnChatOne_Click;
            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text != "")
            {
                if (txtSendMessage.Text.Length < 100)
                {
                    //tiến hành gửi dữ liệu đi
                    string message = (int)manageChooseCases.setting.chatMulti + "*" + user.userName + "(1):" + txtSendMessage.Text.Trim() + ":" + user.linkAvatar;
                    if (txtSendMessage.Text.Contains(':'))
                    {
                        MessageBox.Show("Không được phép nhập kí tự \":\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        handleChat.sendData(client, message);
                        handleChat.writeData(null, user.linkAvatar, txtSendMessage.Text.Trim(), 1, user.userName, pnlMultiChatFrame, this, posY, user.userName, parentDirectory, null, pnlContainsIcon);
                        if (pnlContainsIcon.Visible)
                            pnlContainsIcon.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Bạn chỉ được phép nhập tối đa 100 ký tự");
                }
                txtSendMessage.Clear();
            }
        }
        //==================================================================================================================================


        //========================================= HÀM DÙNG ĐỂ THAO TÁC VỚI SỰ KIỆN BẤM VÀO DATAGRIDVIEW ==================================
        private async void dtGridContainListRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            await handleCellContentClicks.cellClickContent_ListMatches((DataGridView)sender, user, e, apiAddUserIntoMatch, apiGetUserId, myIpAddress, this, client);
        }
        private async void UserControlLists_dtListFriends_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                chat = await handleCellContentClicks.cellClickContent_ListFriends((DataGridView)sender, user, e, apiGetUserId, this, pnlChatOne, userControlLists, btnListFriend, chat, client, apiDeleteFriend);
                if (chat != null)
                {
                    difUsernameUser = chat.Tag.ToString().Split(',')[1];
                    chat.btnSendMsgChatOne_click += Chat_btnSendMsgChatOne_click;
                    chat.btnSendIconChatOne_click += Chat_btnSendIconChatOne_click;
                    chat.btnCloseForm_click += Chat_btnCloseForm_click;
                }
            }
        }
        private async void UserControlLists_dtAllUsers_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            await handleCellContentClicks.cellClickContent_AllUsers((DataGridView)sender, user, e, apiGetUserId, this, client, apiMakeFriend);
        }
        private async void UserControlLists_dtAcceptFriend_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            await handleCellContentClicks.cellClickContent_AcceptFriend((DataGridView)sender, user, e, apiUpdaStatusFriend, client, apiGetUserId, userControlLists, chat);
        }

        //==================================================================================================================================

        //========================================= cÁC HÀM ĐỂ THỰC HIỆN CHỨC NĂNG TƯƠNG TÁC VỚI CÁC NÚT ===================================
        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
            //ẩn giao diện chính đi
            this.Hide();
            InfoUserInterface info = new InfoUserInterface(user, true, client);
            info.Show();
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                await handleLogOutRoom();
                Login.showFormAgain.Show();

                //xóa danh sách chat
                createChatOneFrame.listChats.Clear();
                rcvDataThread.Abort();
                //tiến hành đóng form lại
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private async void btnRank_Click(object sender, EventArgs e)
        {
            JToken tkData = await manageApi.callApiUsingMethodGet(apiGetAllUser);
            List<infoUser> users = JsonConvert.DeserializeObject<List<infoUser>>(tkData.ToString());
            hanleDataIntoDatagridview.displayListRank(users, user, rank);

            loopChildPanel(rank);
        }
        private void btnListFriend_Click(object sender, EventArgs e)
        {
            if (userControlLists.checkReadMessageIntoChat())
                btnListFriend.Text = "Danh sách bạn bè";
            loopChildPanel(userControlLists);
            userControlLists.selectTabControl(1);
        }
        private void btnListAllUsers_Click(object sender, EventArgs e)
        {
            loopChildPanel(userControlLists);
            userControlLists.selectTabControl(0);
        }
        private void btnAcceptFriend_Click(object sender, EventArgs e)
        {
            try
            {
                loopChildPanel(userControlLists);
                userControlLists.selectTabControl(2);
            }
            catch (Exception ex)
            {
            }
        }
        private async void btnHistory_Click(object sender, EventArgs e)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (tkData != null)
            {
                infoUser myUser = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                await hanleDataIntoDatagridview.displayListHistoryMatch(myUser, history, apiGetUserId);
                loopChildPanel(history);
            }
        }
        private async void btnRefreshListMatches_Click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListMatches(dtGridContainListRooms, apiGetListMatches);
        }
        private async void UserControlLists_btnLoadListFriends_click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListFriends(apiGetUserId, user, userControlLists, chat);
        }
        private async void UserControlLists_btnLoadListAllUsers_click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListAllUsers(apiGetUserId, apiGetAllUser, user, userControlLists);

        }
        private async void UserControlLists_btnLoadListAcceptFriends_click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListAcceptFriends(apiGetUserId, user, userControlLists);
        }
        private async void Rank_btnLoadListRank_click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListRanks(apiGetUserId, apiGetAllUser, user, rank);
        }
        private async void History_btnLoadListHistory_click(object sender, EventArgs e)
        {
            await handleReloadList.reloadListHistories(apiGetUserId, user, history);
        }
        private async void btnRandomRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();

                // Random ra một số từ 0 đến số dòng hiện có trong DataGridView
                int randomRowIndex = random.Next(0, dtGridContainListRooms.Rows.Count);


                string idMatch = dtGridContainListRooms.Rows[randomRowIndex].Cells["id"].Value.ToString();
                MessageBox.Show("Đã tham gia vào phòng của người chơi: " + dtGridContainListRooms.Rows[randomRowIndex].Cells["ownerRoom"].Value.ToString());
                //tiến hành lấy ra mã phòng khi click vào
                JToken tkData = await manageApi.callApiUsingMethodPut(new { option = "adduser", id = user.id }, apiAddUserIntoMatch + idMatch);
                if (tkData != null)
                {
                    matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());

                    //lặp qua để kiếm ra id của chủ phòng
                    string id = "";
                    foreach (matchPlayer match1 in match.players)
                    {
                        if (match1.user != user.id)
                        {
                            id = match1.user;
                            break;
                        }
                    }
                    JToken userPlayer = await manageApi.callApiUsingGetMethodID(apiGetUserId + id);

                    if (userPlayer != null)
                    {
                        infoUser difUser = JsonConvert.DeserializeObject<infoUser>(userPlayer.ToString());
                        //gửi sự kiện tới server và cập nhật lại biến user.players lên 2 đơn vị
                        string message = (int)manageChooseCases.setting.joinRoom + "*" + difUser.userName + "+" + idMatch;
                        handleChat.sendData(client, message);

                        string ipServer = hanleDataIntoDatagridview.columnData[randomRowIndex].ToString();
                        MatchInterface player = new MatchInterface(myIpAddress, ipServer, idMatch, ipServer, false, false, 1, match.betPoints, difUser, user, client);  //chủ phòng sẽ là cờ trắng
                        player.Show();

                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy phòng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void UserControlLists_btnFindUser_click(object sender, EventArgs e)
        {
            //nếu người dùng bấm tìm kiếm thì hiển thị lại giao diện dtAllUsers
            string apiUrl = apiGetAllUser + userControlLists.username.Trim() != "" ? apiGetAllUser + "?userName=" + userControlLists.username.Trim() : "";
            JToken tokenData = await manageApi.callApiUsingGetMethodID(apiUrl);
            if (tokenData != null)
            {
                List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
                //hiển thị danh sách user này lên datagridView
                hanleDataIntoDatagridview.displayListUsers(userLists, userControlLists, user);
            }
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            loopChildPanel(createRoom);
        }
        private void Chat_btnCloseForm_click(object sender, EventArgs e)
        {
            pnlChatOne.Hide();
            loopChildPanel(userControlLists);
            //đóng các user control chat one
            foreach (userControlChatOne item in createChatOneFrame.listChats)
                item.Hide();
        }
        private async void CreateRoom_btnAcceptCreateRoom_click(object sender, EventArgs e)
        {
            if (string.Equals(createRoom.name.Trim(), "") || string.Equals(createRoom.betpoint.Trim(), ""))
            {
                MessageBox.Show("Thông tin nhập vào không được bỏ trống");
            }
            else
            {
                try
                {
                    int betPoint = int.Parse(createRoom.betpoint.Trim());
                    if (betPoint == 0)
                    {
                        MessageBox.Show("Vui lòng nhập điểm cược lớn hơn 0");
                        return;
                    }
                    if (betPoint > user.point)
                    {
                        MessageBox.Show("Bạn không đủ điểm để đặt mức cược này, vui lòng nhập điểm cược khác");
                        return;
                    }
                    var data = new
                    {
                        id = user.id,
                        betPoints = betPoint,
                        roomName = createRoom.name.Trim(),
                        ownerRoom = user.userName,
                        ipRoom = myIpAddress
                    };
                    JToken tkData = await manageApi.callApiUsingMethodPost(data, apiCreateRoom);
                    if (tkData != null)
                    {
                        MessageBox.Show("Tạo phòng thành công");
                        await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
                        matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());
                        string message = (int)manageChooseCases.setting.createRoom + "*" + user.userName;
                        handleChat.sendData(client, message);

                        //tạo và tham gia vào phòng
                        this.Hide();
                        MatchInterface admin = new MatchInterface(myIpAddress, null, match._id, myIpAddress, true, true, 0, betPoint, null, user, client);  //chủ phòng sẽ là cờ trắng
                        admin.Show();

                        pnlContainsChild.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tạo phòng thất bại, vui lòng thực hiện lại");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Điểm cược không hợp lệ, vui lòng nhập lại");
                }
            }
        }
        private void CreateRoom_btnCloseCreateRoom_click(object sender, EventArgs e)
        {
            createRoom.Hide();
            pnlContainsChild.Hide();
        }
        private void Rank_btnCloseRank_click(object sender, EventArgs e)
        {
            rank.Hide();
            pnlContainsChild.Hide();
        }
        private void History_btnCloseHistory_click(object sender, EventArgs e)
        {
            history.Hide();
            pnlContainsChild.Hide();
        }
        private void UserControlLists_btnCloseList_click(object sender, EventArgs e)
        {
            if (pnlChatOne.Visible)
                pnlChatOne.Hide();
            userControlLists.Hide();
            pnlContainsChild.Hide();
        }
        private async void LobbyInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            await handleLogOutRoom();
        }
        //==================================================================================================================================
    }
}
