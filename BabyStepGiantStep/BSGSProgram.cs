using System;
using System.Collections.Generic;
using System.Numerics;

namespace Crypto
{
    static class BSGSProgram
    {
  
        static void Main(string[] args)
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
