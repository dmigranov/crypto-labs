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
            BigInteger rem, result = 1, cur = val;
            while(exp > 0)
            {
                rem = exp % 2;
                exp = exp / 2;
                //8 - 0001

                if (rem != 0)
                    result = (cur * result) % mod;
                cur = (cur * cur) % mod;
            }

            return result;
        }
    }
}
