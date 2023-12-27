using HashCraft.CryptoAlgorithm;
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
        private readonly ICryptoAlgorithm cryptoAlgorithm;

        public HashService(IHashAlgorithm algorithm, ICryptoAlgorithm cryptoAlgorithm)
        {
            hashAlgorithm = algorithm;
            this.cryptoAlgorithm = cryptoAlgorithm;
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
            if (use3Des == true)
            {
                var hash = ComputeHash(ComputeHash(input) + salt);
                return cryptoAlgorithm.Encrypt(hash, "YourSecretKey123");
            }
            else
            {
                return ComputeHash(ComputeHash(input) + salt);
            }
        }
    }
}
