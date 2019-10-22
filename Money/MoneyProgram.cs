using System;
using System.Numerics;


namespace Crypto
{
    class MoneyProgram
    {
        static void Main(string[] args)
        {
            BigInteger p, q;

            p = AskForBigIntegerInput("Please enter prime number p, p > 1", x => x > 1);

            q = AskForBigIntegerInput("Please enter prime number q, q > 1", x => x > 1);

            MoneyTools.SimulateMoneyExchange(p, q);
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
