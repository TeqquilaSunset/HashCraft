using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashCraft.CryptoAlgorithm
{
    internal class TripleDes : ICryptoAlgorithm
    {
        public string Decrypt(string input, byte[] key)
        {
            using (var tripleDes = TripleDES.Create())
            {
                tripleDes.Key = key;
                tripleDes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = tripleDes.CreateDecryptor();
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(input);
                byte[] encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);

                var result = ConvertBytesToString(encryptedData);
                return result;

            }
        }

        public string Encrypt(string input, byte[] key)
        {
            using (var tripleDes = TripleDES.Create())
            {
                tripleDes.Key = key;
                tripleDes.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = tripleDes.CreateEncryptor();
                byte[] dataToDecrypt = Convert.FromBase64String(input);
                byte[] decryptedData = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);

                var result = ConvertBytesToString(decryptedData);
                return result;
            }
        }

        private string ConvertBytesToString(byte[] bytes)
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
