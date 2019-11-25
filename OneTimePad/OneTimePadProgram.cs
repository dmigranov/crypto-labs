using System;
using System.Numerics;
using System.Threading.Tasks;

namespace OneTimePad
{
    static class OneTimePadProgram
    {
        
        static void Main()
        {
            
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
