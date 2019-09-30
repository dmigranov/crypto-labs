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

        public static void EncryptMessage(BigInteger g, BigInteger receiverPublicKey, BigInteger p, BigInteger message, out BigInteger y, out BigInteger k)
        {
            Random random = new Random();
            int s = random.Next(0, (int)p);

            BigInteger r = CryptoTools.ModuloPower(g, s, p);

            k = CryptoTools.ModuloPower(g, r, p);
            y = (message * CryptoTools.ModuloPower(receiverPublicKey, r, p)) % p;

        }

        public static BigInteger DecryptMessage(BigInteger receiverPrivateKey, BigInteger p, BigInteger y, BigInteger w)
        {
            return 0;

        }
    }
}
