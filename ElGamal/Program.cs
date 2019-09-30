using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger p, g;

            p = AskForBigIntegerInput("Please enter p, p > 0", x => x > 0);
            Console.WriteLine($"p is {p}");

            //g = AskForBigIntegerInput("Please enter p, p > 0", x => x > 0);


        }

        private static BigInteger AskForBigIntegerInput(string message, Predicate<BigInteger> cond)
        {
            BigInteger x;
            do
            {
            Cycle:
                Console.WriteLine(message);
                string s = Console.ReadLine();
                try
                {
                    x = BigInteger.Parse(s);
                }
                catch (FormatException)
                {
                    goto Cycle;
                }
            }
            while (!cond(x));

            return x;
        }
    }


}

