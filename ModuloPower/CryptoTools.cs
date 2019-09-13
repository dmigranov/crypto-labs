using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ModuloPower
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
            //в тетради g^S mod p, но какая разница, если число из того же диапазона? g - примитивный элемент по условию?
            //таким образом, g^s из того же диапазона
            //а просто так генерировать случайные BigInt мы не умеем...
            Random r = new Random();
            int s = r.Next(0, (int)p);

            //todo: генерировать просто случайное БОЛЬШОе число (необяз. из  диапазона)
            return ModuloPower(g, s, p);
        }

        public static BigInteger GenerateDiffieHellmanPublicKey(BigInteger g, BigInteger privateKey, BigInteger p)
        {
            return ModuloPower(g, privateKey, p);
        }


    }
}
