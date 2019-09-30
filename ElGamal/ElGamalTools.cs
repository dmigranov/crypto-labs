using System;
using System.Numerics;

namespace Crypto
{
    class ElGamalTools
    {
        public static BigInteger GenerateElGamalPrivateKey(BigInteger g, BigInteger p)
        {
            Random r = new Random();
            int s = r.Next(0, (int)p);

            return CryptoTools.ModuloPower(g, s, p);    //т.к s - это случайное число в диапазоне только от 0 до MAX_INT
        }

        public static BigInteger GenerateElGamalPublicKey(BigInteger g, BigInteger privateKey, BigInteger p)
        {
            return CryptoTools.ModuloPower(g, privateKey, p);
        }
    }
}
