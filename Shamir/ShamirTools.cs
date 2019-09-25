using System;
using System.Numerics;


namespace Crypto
{
    class ShamirTools
    {
        public static void GenerateShamirPrivateKeys(BigInteger p, out BigInteger c, out BigInteger d)
        {
            Random r = new Random();
            BigInteger cCandidate;
            do
            {
                cCandidate = r.Next(0, int.MaxValue);
                CryptoTools.EuclidAlgorithm();
            }
        }
    }
}
