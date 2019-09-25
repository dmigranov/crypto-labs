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
            } while (ret != 1);
            c = cCandidate;
            if (dCandidate < 0)
                dCandidate += (p - 1);
            d = dCandidate;

            //1 взаимно проста со всеми числами и 1 * 1 = 1. Это нормально?
        }
    }
}
