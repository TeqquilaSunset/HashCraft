using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCraft.CryptoAlgorithm
{
    internal interface ICryptoAlgorithm
    {
        public string Encrypt(string input, string key);
        public string Decrypt(string input, string key);
    }
}
