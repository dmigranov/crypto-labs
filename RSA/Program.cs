using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger p, q, d, m;

            p = AskForBigIntegerInput("Please enter prime number p, p > 0", x => x > 0);
            Console.WriteLine($"p is {p}");

            q = AskForBigIntegerInput("Please enter prime number q, q > 0", x => x > 0);
            Console.WriteLine($"q is {q}");

            d = AskForBigIntegerInput("Please enter d, (d, phi(p*q) = 1)", x => true);
            Console.WriteLine($"d is {d}");

            m = AskForBigIntegerInput("Please enter m, x >= 0 and x < p", x => x >= 0 && x < p);
            Console.WriteLine($"Message is {m}");

            RSATools.SimulateRSAExchange(p, q, d, m);

            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }

        private static BigInteger AskForBigIntegerInput(string message, Predicate<BigInteger> cond)
        {
            BigInteger x;

        Cycle:
            Console.WriteLine(message);
            string s = Console.ReadLine();
            try
            {
                x = BigInteger.Parse(s);
                if (!cond(x))
                    goto Cycle;
            }
            catch (FormatException)
            {
                goto Cycle;
            }

            return x;
        }
    }
}

