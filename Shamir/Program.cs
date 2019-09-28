using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
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
            ShamirTools.GenerateShamirPrivateKeys(p, out cA, out dA);
            Console.WriteLine($"Alice generated private keys cA = {cA}, dA = {dA}");
            ShamirTools.GenerateShamirPrivateKeys(p, out cB, out dB);
            Console.WriteLine($"Bob generated private keys cB = {cB}, dB = {dB}");

            BigInteger x = -1;

            do
            {
                Console.WriteLine("Please enter message, x < p");
                string s = Console.ReadLine();
                try
                {
                    x = BigInteger.Parse(s);
                }
                catch (FormatException e)
                {
                    x = -1;
                }
            }
            while (x < 0 || x >= p);

            Console.WriteLine($"Message is {x}");
        }

    }
}
