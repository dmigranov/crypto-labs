using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x, y, a = 0, b;
            CryptoTools.EuclidAlgorithm(a, b, ref x, ref y);
            Console.WriteLine(x);
        }

  
    }
}
