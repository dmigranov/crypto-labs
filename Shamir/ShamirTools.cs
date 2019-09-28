using System;
using System.Numerics;


namespace Crypto
{
    class ShamirTools
    {
     
        
        public static void GenerateShamirPrivateKeys(BigInteger p, out BigInteger c, out BigInteger d)
        {
            Random r = new Random();
            BigInteger cCandidate, dCandidate, ret;
            do
            {
                BigInteger temp;
                cCandidate = r.Next(1, (int)p);
                ret = CryptoTools.EuclidAlgorithm(p - 1, cCandidate, out temp, out dCandidate);
            } while (ret != 1); //крутимся пока не найдём такое c: (c, p - 1) = 1. тогда d обратное к c
            c = cCandidate;
            if (dCandidate < 0)
                dCandidate += (p - 1);
            d = dCandidate;
        }
    }
}
