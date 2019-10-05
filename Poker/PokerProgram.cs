using System;
using System.Numerics;


namespace Crypto
{
    class PokerProgram
    {
        static void Main(string[] args)
        {
            BigInteger p;

            p = AskForBigIntegerInput("Please enter prime number p, p > 0", x => x > 0);
            Console.WriteLine($"p is {p}");


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
