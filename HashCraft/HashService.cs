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

        public string ComputeHash(string input)
        {
            return hashAlgorithm.ComputeHash(input);
        }

        public string ComputeHashWithSalt(string input, string salt)
        {
            return ComputeHash(ComputeHash(input) + salt);
        }
    }
}
