using System;
using System.Numerics;

namespace Crypto
{
    class CryptoTools
    {
        static Random rand = new Random();

        public static BigInteger ModuloPower(BigInteger val, BigInteger exp, BigInteger mod)
        {
            if (exp < 0 || mod < 0)
                throw new ArgumentException("Negative modulo or exponent");
            BigInteger rem, result = 1, cur = val;
            while (exp > 0)
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
        
        /// <returns>a random big integer from [minValue, maxValue)</returns>
        public static BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            BigInteger result = 0;
            do
            {
                int length = (int)Math.Ceiling(BigInteger.Log(maxValue, 2));
                int numBytes = (int)Math.Ceiling(length / 8.0);
                byte[] data = new byte[numBytes];
                rand.NextBytes(data);
                result = new BigInteger(data);
            } while (result >= maxValue || result < minValue);
            return result;
        }
    }
}
