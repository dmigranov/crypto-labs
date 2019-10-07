using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class RSASignatureProgram
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

            m = AskForBigIntegerInput($"Please enter m, m < N = {p * q} (h(m) = m)", x => x >= 0 && x < p * q);
            Console.WriteLine($"Message is {m}");
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
