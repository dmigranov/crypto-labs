using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x, y, a = 12, b = 7, r;
            r = CryptoTools.EuclidAlgorithm(a, b, out x, out y);
            Console.WriteLine($"{x} {y} r = {r}");

            string pString;

            if (args.Length == 0)
            {
                Console.WriteLine("No arguments, please enter p");
                pString = Console.ReadLine();
            }
            else pString = args[0];

            BigInteger p;
            try
            {
                p = BigInteger.Parse(pString);
                SimulateShamirExchange(p);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Press any key to exit: ");
            Console.ReadKey();

        }


        private static void SimulateShamirExchange(BigInteger p)
        {
            BigInteger cA, dA, cB, dB;

        }

    }
}
