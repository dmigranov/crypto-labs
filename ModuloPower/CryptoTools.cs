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
    }
}
