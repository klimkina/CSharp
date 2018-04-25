using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VWA4Common.Security
{
    public class DESEncryption
    {
        //8 byte key for DES encryption
        private readonly byte[] _key = new byte[] { 0xBA, 0x87, 0x09, 0xDC, 0xFE, 0x65, 0x43, 0x21 };
        private readonly byte[] _IV = new byte[] {  0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public string EncryptToString(string data)
        {
            var des = new DESCryptoServiceProvider();
            var input = Encoding.UTF8.GetBytes(data);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(_key, _IV), CryptoStreamMode.Write);

            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        public string DecryptString(string data)
        {
            var input = Convert.FromBase64String(data);
            var des = new DESCryptoServiceProvider();
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(_key, _IV), CryptoStreamMode.Write);

            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
