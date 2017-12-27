using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace FileUpload
{
    public static class Encryption
    {
        private static byte[] sharedkey = {0x03, 0x02, 0x03, 0x05, 0x01, 0x0B, 0x0D, 0x11, 0x12, 0x11,
                    0x0D, 0x0B, 0x11, 0x02, 0x04, 0x08};

        private static byte[] sharedvector = {0x05, 0x02, 0x03, 0x01, 0x07, 0x0B, 0x0D, 0x11, 0x13, 0x11,
                    0x0D, 0x0B, 0x07, 0x02, 0x04, 0x08};

        public static string Encrypt(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                byte[] toEncrypt = Encoding.UTF8.GetBytes(val);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateEncryptor(sharedkey, sharedvector), CryptoStreamMode.Write);
                cs.Write(toEncrypt, 0, toEncrypt.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }

            return string.Empty;
        }

        public static string Decrypt(string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                byte[] toDecrypt = Convert.FromBase64String(val);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateDecryptor(sharedkey, sharedvector), CryptoStreamMode.Write);

                cs.Write(toDecrypt, 0, toDecrypt.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }

            return string.Empty;
        }
    }
}