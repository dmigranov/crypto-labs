using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x, y, a = 4, b = 7;
            Console.WriteLine($"{a} {b}");
            CryptoTools.EuclidAlgorithm(a, b, out x, out y);
            Console.WriteLine($"{a} {b}");
        }


    }
}
