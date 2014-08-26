using System.IO;
using System.Security.Cryptography;

namespace FileEncryption.WebApp
{
    public class FileEncryptionHelper
    {
        public static void Encrypt(string inputFilePath, string outputfilePath, string encryptionKey)
        {
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var fsOutput = new FileStream(outputfilePath, FileMode.Create))
                {
                    using (var cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (var fsInput = new FileStream(inputFilePath, FileMode.Open))
                        {
                            int data;
                            while ((data = fsInput.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }

        public static void Encrypt(FileStream inputStream, string outputfilePath, string encryptionKey)
        {
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var fsOutput = new FileStream(outputfilePath, FileMode.Create))
                {
                    using (var cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (inputStream)
                        {
                            int data;
                            while ((data = inputStream.ReadByte()) != -1)
                            {
                                cs.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }

        public static void Decrypt(string inputFilePath, string outputfilePath, string encryptionKey)
        {
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var fsInput = new FileStream(inputFilePath, FileMode.Open))
                {
                    using (var cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (var fsOutput = new FileStream(outputfilePath, FileMode.Create))
                        {
                            int data;
                            while ((data = cs.ReadByte()) != -1)
                            {
                                fsOutput.WriteByte((byte)data);
                            }
                        }
                    }
                }
            }
        }
    }
}