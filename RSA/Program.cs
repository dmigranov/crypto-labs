using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger p, q, m;

            p = AskForBigIntegerInput("Please enter prime number p, p > 0", x => x > 0);
            Console.WriteLine($"p is {p}");

            q = AskForBigIntegerInput("Please enter prime number q, q > 0", x => x > 0);
            Console.WriteLine($"q is {q}");

            m = AskForBigIntegerInput("Please enter m, x >= 0 and x < p", x => x >= 0 && x < p);
           

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

