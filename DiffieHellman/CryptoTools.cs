using System;
using System.Numerics;

namespace Crypto
{
    class CryptoTools
    {
        //System.Numerics.BigInteger ModPow
        public static BigInteger ModuloPower(BigInteger val, BigInteger exp, BigInteger mod)
        {
            int count = 0;
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
                    //count++;
                }
                cur = (cur * cur) % mod;
                //count++;
            }
            return result;
        }

        public static BigInteger GenerateDiffieHellmanPrivateKey(BigInteger g, BigInteger p)
        {
            Random r = new Random();
            int s = r.Next(0, (int)p);

            return ModuloPower(g, s, p);    //т.к s - это случайное число в диапазоне только от 0 до MAX_INT
        }

        public static BigInteger GenerateDiffieHellmanPublicKey(BigInteger g, BigInteger privateKey, BigInteger p)
        {
            return ModuloPower(g, privateKey, p);
        }
    }
}
