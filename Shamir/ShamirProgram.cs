using System;
using System.Numerics;

namespace Crypto
{
    class ShamirProgram
    {
        static void Main(string[] args)
        {
            string pString;

            if (args.Length == 0)
            {
                Console.WriteLine("No arguments, please enter prime number p:");
                pString = Console.ReadLine();
            }
            else pString = args[0];

            BigInteger p;
            try
            {
                p = BigInteger.Parse(pString);
                //SimulateShamirExchange(p);
                SimulateShamirExchange(p, 15, 7, 6);
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
                catch (FormatException)
                {
                    x = -1;
                }
            }
            while (x < 0 || x >= p);

            Console.WriteLine($"Message is {x}");

            BigInteger y = CryptoTools.ModuloPower(x, cA, p);
            Console.WriteLine($"Alice calculated y = {y} and sent it to Bob");

            BigInteger z = CryptoTools.ModuloPower(y, cB, p);
            Console.WriteLine($"Bob calculated z = {z} and sent it to Alice");

            BigInteger u = CryptoTools.ModuloPower(z, dA, p);
            Console.WriteLine($"Alice calculated u = {u} and sent it to Bob");

            BigInteger w = CryptoTools.ModuloPower(u, dB, p);
            Console.WriteLine($"Bob calculated w = {w}");
        }

        private static void SimulateShamirExchange(BigInteger p, BigInteger cA, BigInteger cB, BigInteger m)
        {
            BigInteger dA, dB;
            dA = ShamirTools.GenerateShamirPrivateKeyUsingAnother(p, cA);
            Console.WriteLine($"dA = {dA}");
            dB = ShamirTools.GenerateShamirPrivateKeyUsingAnother(p, cB);
            Console.WriteLine($"dB = {dB}");

            BigInteger x = m;


            Console.WriteLine($"Message is {x}");

            BigInteger y = CryptoTools.ModuloPower(x, cA, p);
            Console.WriteLine($"Alice calculated y = {y} and sent it to Bob");

            BigInteger z = CryptoTools.ModuloPower(y, cB, p);
            Console.WriteLine($"Bob calculated z = {z} and sent it to Alice");

            BigInteger u = CryptoTools.ModuloPower(z, dA, p);
            Console.WriteLine($"Alice calculated u = {u} and sent it to Bob");

            BigInteger w = CryptoTools.ModuloPower(u, dB, p);
            Console.WriteLine($"Bob calculated w = {w}");
        }

    }

    
}

