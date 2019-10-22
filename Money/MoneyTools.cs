using System;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class MoneyTools
    {
        public static void SimulateMoneyExchange(BigInteger p, BigInteger q)
        {
            Console.WriteLine($"Bank's private p is {p}");
            Console.WriteLine($"Bank's private q is {q}");
            BigInteger N = p * q, phi = (p - 1) * (q - 1);
            Console.WriteLine($"Bank's public N is {N}, phi(N) = {phi}");

            BigInteger c, d;
            GenerateInverseNumbers
        }
    }
}
