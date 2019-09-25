using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x, y, a, b;
            CryptoTools.EuclidAlgorithm(a, b, out x, out y);
            Console.WriteLine(x);
        }

  
    }
}
