using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace HashCraft
{
    internal class HashAlgorithm
    {
        public string ComputeSha256(string mystring)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(mystring));
                return ConvertBytesToStirng(bytes);
            }
        }

        public string CreateHashPasswordWithSalt(string password, string salt)
        {
            return ComputeSha256(ComputeSha256(password) + salt);
        }

        public string ConvertBytesToStirng(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
