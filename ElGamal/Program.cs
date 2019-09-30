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

            g = AskForBigIntegerInput("Please enter g, p > 0", x => x > 1 && x < p -1);
            Console.WriteLine($"g is {g}");



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
                if(!cond(x))
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

