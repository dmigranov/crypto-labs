using System;
using System.Numerics;

namespace Crypto
{
    class CryptoTools
    {
        public static BigInteger ModuloPower(BigInteger val, BigInteger exp, BigInteger mod)
        {
            if (exp < 0 || mod < 0)
                throw new ArgumentException("Negative modulo or exponent");
            BigInteger rem, result = 1, cur = val;
            while(exp > 0)
            {
                rem = exp % 2;
                exp = exp / 2;

                if (rem != 0)
                { 
                    result = (cur * result) % mod;
                }
                cur = (cur * cur) % mod;
            }
            return result;
        }

        public static BigInteger EuclidAlgorithm(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
        {
            x = 45;
            return 0;
        }

    }
}
