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

            //k,1 < k < p- 1 (k,p-1) = 1

            BigInteger k, kRev, ret, t1, t2;
            do
            {
                k = CryptoTools.GenerateRandomBigInteger(2, p - 1);
                ret = CryptoTools.EuclidAlgorithm(p - 1, k, out t1, out kRev);
            } while (ret != 1);
            
            if (kRev < 0)
                kRev += (p - 1);
        
            Console.WriteLine($"Alice generated k = {k}, (k, p - 1) = 1; k^-1 = {kRev}");

            BigInteger r = CryptoTools.ModuloPower(g, k, p);

            Console.WriteLine($"Alice calculated r = {r}");


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

        public static void SimulateElGamalExchange(BigInteger p, BigInteger g, BigInteger m)
        {
            Console.WriteLine($"Message is {m}");

            BigInteger dB, cB;
            cB = GenerateElGamalPrivateKey(g, p);
            dB = GenerateElGamalPublicKey(g, cB, p);
            Console.WriteLine($"Bob generated private key {cB} and public key {dB}");

            BigInteger k, y;
            EncryptMessage(g, dB, p, m, out y, out k);
            Console.WriteLine($"Alice calculated k = {k} and y = {y} and sent them to Bob");

            BigInteger w;
            w = DecryptMessage(cB, p, y, k);
            Console.WriteLine($"Bob deciphered message {w}");
        }


        private static BigInteger CalculateHash(BigInteger m)
        {
            return m;
        }
    }
}
