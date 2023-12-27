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
        public string Decrypt(string input, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDes = new())
            {
                tripleDes.Key = Encoding.UTF8.GetBytes(key);
                tripleDes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = tripleDes.CreateEncryptor();
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(input);
                byte[] encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);

                return Convert.ToBase64String(encryptedData);
            }
        }

        public string Encrypt(string input, string key)
        {
            using (TripleDESCryptoServiceProvider tripleDes = new())
            {
                tripleDes.Key = Encoding.UTF8.GetBytes(key);
                tripleDes.Mode = CipherMode.ECB;

                ICryptoTransform decryptor = tripleDes.CreateDecryptor();
                byte[] dataToDecrypt = Convert.FromBase64String(input);
                byte[] decryptedData = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}
