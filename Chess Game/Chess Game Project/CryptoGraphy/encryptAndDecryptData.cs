using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Game_Project.CryptoGraphy
{
    internal class encryptAndDecryptData
    {
        static byte[] key = new byte[]
        {
            0x54, 0x68, 0x69, 0x73, 0x49, 0x73, 0x54, 0x68, 0x65, 0x46, 0x69, 0x78, 0x65, 0x64, 0x4B, 0x65, // 16-byte key
            0x79, 0x31, 0x32, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00  // Padding bytes
        };

        static byte[] iv = new byte[]
        {
             0x54, 0x68, 0x69, 0x73, 0x49, 0x73, 0x54, 0x68, 0x65, 0x46, 0x69, 0x78, 0x65, 0x64, 0x49, 0x56  // 16-byte IV
        };
        public static string DecryptMessage(string encryptedMessage)
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
    }
}
