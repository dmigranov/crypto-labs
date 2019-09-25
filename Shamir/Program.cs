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


            BigInteger p;
            string pString;

            if (args.Length == 0)
            {
                Console.WriteLine("No arguments, please enter p");
                pString = Console.ReadLine();
            }
            else pString = args[0];

        }


    }
}
