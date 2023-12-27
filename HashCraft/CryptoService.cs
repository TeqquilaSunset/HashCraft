using HashCraft.CryptoAlgorithm;
using HashCraft.HashAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCraft
{
    internal class CryptoService
    {
        private readonly ICryptoAlgorithm _cryptoAlgorithm;

        public CryptoService(ICryptoAlgorithm cryptoAlgorithm)
        {
            _cryptoAlgorithm = cryptoAlgorithm;
        }

        public string Encrypt(string input, string key)
        {
            return _cryptoAlgorithm.Encrypt(input, key);
        }
        public string Decrypt(string input, string key)
        {
            return _cryptoAlgorithm.Decrypt(input, key);
        }
    }
}
