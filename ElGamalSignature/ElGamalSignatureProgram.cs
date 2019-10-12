using System;
using System.Numerics;

namespace Crypto
{
    class ElGamalSignatureProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to do? s - simulate signing message and checking it, c - just checking");
            ConsoleKeyInfo c = Console.ReadKey();
            Console.WriteLine();
            if (c.KeyChar == 's')
            {
                BigInteger p, g, m;

                p = AskForBigIntegerInput("Please enter p, p > 1", x => x > 1);
                Console.WriteLine($"p is {p}");

                g = AskForBigIntegerInput($"Please enter g, g > 1 and g < {p - 1}", x => x > 1 && x < p - 1);
                Console.WriteLine($"g is {g}");

                m = AskForBigIntegerInput($"Please enter m, m > 1 and m < {p}", x => x > 1 && x < p);
                ElGamalSignatureTools.SimulateElGamalSigning(p, g, m);
            }
            else if (c.KeyChar == 'c')
            {
                BigInteger p, r, s, m, y, g;

                p = AskForBigIntegerInput("Please enter p, p > 1", x => x > 1);
                Console.WriteLine($"p is {p}");

                d = AskForBigIntegerInput("Please enter d, d > 0, (d, phi(N) = 1)", x => x > 0);
                Console.WriteLine($"d is {d}");

                m = AskForBigIntegerInput($"Please enter m, m < N = {N} (h(m) = m)", x => x >= 0 && x < N);
                Console.WriteLine($"Message is {m}");

                s = AskForBigIntegerInput($"Please enter s, s < N = {N}", x => x >= 0 && x < N);
                Console.WriteLine($"Signature is {s}");

                ElGamalSignatureTools.SimulateElGamalChecking(m, r, s, p, y, g);
            }
            else Console.WriteLine("Wrong input!");
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

