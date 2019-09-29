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
            } while (ret != 1); //крутимся пока не найдём такое cCandidate: (cCandidate, p - 1) = 1. тогда dCandidate обратное к cCandidate с точностью до модуля
            c = cCandidate;
            if (dCandidate < 0)
                dCandidate += (p - 1);
            d = dCandidate;
        }

        public static BigInteger GenerateShamirPrivateKeyUsingAnother(BigInteger p, BigInteger c)
        {
            BigInteger temp, d, ret = CryptoTools.EuclidAlgorithm(p - 1, c, out temp, out d);
            if (d < 0)
                d += (p - 1);
            return d;
            
        }
    }
}
