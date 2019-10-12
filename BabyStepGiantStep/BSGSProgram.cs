using System;
using System.Collections.Generic;
using System.Numerics;

namespace Crypto
{
    static class BSGSProgram
    {
  
        static void Main(string[] args)
        {
            Console.WriteLine("a^x mod p = y");

            BigInteger p, a, y;

            p = AskForBigIntegerInput("Please enter p, p > 1", x => x > 1);
            Console.WriteLine($"p is {p}");

            a = AskForBigIntegerInput($"Please enter a, a >= 0 and a < {p}", x => x >= 0 && x < p);
            Console.WriteLine($"a is {a}");

            y = AskForBigIntegerInput($"Please enter y, y >= 0 and y < {p}", x => x >= 0 && x < p);
            Console.WriteLine($"y is {y}");

            BSGSTools.SolveEquation(y, a, p);
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
