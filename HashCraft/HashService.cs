using HashCraft.HashAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCraft
{
    internal class HashService
    {
        private readonly IHashAlgorithm hashAlgorithm;

        public HashService(IHashAlgorithm algorithm)
        {
            hashAlgorithm = algorithm;
        }

        /// <summary>
        /// Генерация хеша без учета соли
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ComputeHash(string input)
        {
            return hashAlgorithm.ComputeHash(input);
        }

        /// <summary>
        /// Генерация хеша с учетом соли
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string ComputeHashWithSalt(string input, string salt, bool use3Des)
        {
            return ComputeHash(ComputeHash(input) + salt);
            // todo: add TripleDESCrypto
        }
    }
}
