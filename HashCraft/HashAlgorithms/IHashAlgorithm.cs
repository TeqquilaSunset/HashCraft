using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCraft.HashAlgorithms
{
    internal interface IHashAlgorithm
    {
        string ComputeHash(string input);
    }
}
