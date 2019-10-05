using System;
using System.Numerics;

namespace Crypto
{
    class RSAProgram
    {
        static void Main(string[] args)
        {
            BigInteger p, q, d, m;

            p = AskForBigIntegerInput("Please enter prime number p, p > 0", x => x > 0);
            Console.WriteLine($"p is {p}");

            q = AskForBigIntegerInput("Please enter prime number q, q > 0", x => x > 0);
            Console.WriteLine($"q is {q}");

            d = AskForBigIntegerInput("Please enter d, d > 0, (d, phi(p*q) = 1)", x => x > 0);
            Console.WriteLine($"d is {d}");

            m = AskForBigIntegerInput($"Please enter m, m < N = {p * q}", x => x >= 0 && x < p*q);
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

