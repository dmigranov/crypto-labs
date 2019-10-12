using System;
using System.Numerics;

namespace Crypto
{
    class ElGamalSignatureTools
    {
        public static void SimulateElGamalSigning(BigInteger p, BigInteger g, BigInteger m)
        {
            Console.WriteLine($"Alice gonna sign messsage m = {m} and send it to Bob");
            BigInteger x = CryptoTools.GenerateRandomBigInteger(2, p - 1);
            BigInteger y = CryptoTools.ModuloPower(g, x, p);

            Console.WriteLine($"Alice generated her private key x = {x} and calculated her public key y = {y}");


            BigInteger h = CalculateHash(m);
            Console.WriteLine($"Hash function of message {m} is {h} (h(m) = m)");

            BigInteger r, s;
            SignMessage(h, g, p, x, out r, out s);           

            Console.WriteLine($"ALice signed her message and sent <m = {m}, r = {r}, s = {s}>");

            
        }

        private static void SignMessage(BigInteger h, BigInteger g, BigInteger p, BigInteger x, out BigInteger r, out BigInteger s)
        {
            BigInteger k, kRev, ret, temp;
            do
            {
                k = CryptoTools.GenerateRandomBigInteger(2, p - 1);
                ret = CryptoTools.EuclidAlgorithm(p - 1, k, out temp, out kRev);
            } while (ret != 1);
            
            if (kRev < 0)
                kRev += (p - 1);
        
            r = CryptoTools.ModuloPower(g, k, p);

            BigInteger u = (h - x * r) % (p - 1);
            s = (kRev * u) % (p - 1);
        }

        private static BigInteger GenerateElGamalPrivateKey(BigInteger g, BigInteger p)
        {
            return CryptoTools.GenerateRandomBigInteger(2, p - 1);
        }

        private static BigInteger GenerateElGamalPublicKey(BigInteger g, BigInteger privateKey, BigInteger p)
        {
            return CryptoTools.ModuloPower(g, privateKey, p);
        }

        private static void EncryptMessage(BigInteger g, BigInteger receiverPublicKey, BigInteger p, BigInteger message, out BigInteger y, out BigInteger k)
        {
            BigInteger r = CryptoTools.GenerateRandomBigInteger(1, p - 1);

            k = CryptoTools.ModuloPower(g, r, p);
            y = (message * CryptoTools.ModuloPower(receiverPublicKey, r, p)) % p;
        }

        private static BigInteger DecryptMessage(BigInteger receiverPrivateKey, BigInteger p, BigInteger y, BigInteger k)
        {
            return y * CryptoTools.ModuloPower(k, p - receiverPrivateKey - 1, p) % p;
        }

        private static BigInteger CalculateHash(BigInteger m)
        {
            return m;
        }

        private static bool CheckSignature(BigInteger m, BigInteger r, BigInteger s, BigInteger p, BigIntger y)
        {
            BigInteger h = CalculateHash(m);
            
            return w == h;
        }
    }
}
