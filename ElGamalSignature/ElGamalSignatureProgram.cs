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

                p = AskForBigIntegerInput("Please enter prime number p, p > 1", x => x > 1);
                Console.WriteLine($"p is {p}");

                g = AskForBigIntegerInput($"Please enter g, g > 1 and g < {p - 1}", x => x > 1 && x < p - 1);
                Console.WriteLine($"g is {g}");

                m = AskForBigIntegerInput($"Please enter message m, m > 1 and m < {p}, h(m) = m", x => x > 1 && x < p);
                Console.WriteLine($"m is {m}");

                r = AskForBigIntegerInput($"Please enter r, r > 0 and r < {p}", x => x > 0 && x < p);
                Console.WriteLine($"r is {r}");

                s = AskForBigIntegerInput($"Please enter s, r > 0 and r < {p - 1}", x => x > 0 && x < p - 1);
                Console.WriteLine($"s is {s}");

                y = AskForBigIntegerInput($"Please enter public key y, y > 0 and y < {p}", x => x > 0 && x < p);
                Console.WriteLine($"y is {y}");

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

