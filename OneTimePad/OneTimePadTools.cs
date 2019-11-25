using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class OneTimePadTools
    {

        internal static void SendMessage(int n, BigInteger msg)
        {
            BigInteger k = GenerateKey(n);
            Console.WriteLine($"Secret key k = {k} generated");

        }

        private static BigInteger GenerateKey(int n)
        {
            throw new NotImplementedException();
        }
    }
}
