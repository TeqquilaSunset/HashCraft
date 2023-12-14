using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HashCraft;

namespace HashCraft.HashAlgorithms
{
    internal class Sha256HashAlgorithm : IHashAlgorithm
    {
        /// <summary>
        /// Вычисление хеша с помощью Sha256
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return ConvertBytesToString(bytes);
            }
        }

        /// <summary>
        /// Конвертирует массив байт в строку
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
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
