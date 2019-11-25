using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Crypto
{
    static class OneTimePadProgram
    {
        
        static void Main()
        {
            BigInteger n = AskForBigIntegerInput("Please enter n, n > 0", x => x > 0);

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
