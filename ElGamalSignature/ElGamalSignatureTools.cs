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

            Console.WriteLine($"Alice signed her message and sent <m = {m}, r = {r}, s = {s}> to Bob");
            Console.WriteLine("Bob received them and checked if signature is correct:");
            SimulateElGamalChecking(m, r, s, p, y, g);
        }

        private static void SimulateElGamalChecking(BigInteger m, BigInteger r, BigInteger s, BigInteger p, BigInteger y, BigInteger g)
        {
            if (CheckSignature(m, r, s, p, y, g) == true)
                Console.WriteLine("Signature is correct!");
            else
                Console.WriteLine("Signature is not correct!");
        }

        private static void SignMessage(BigInteger h, BigInteger g, BigInteger p, BigInteger x, out BigInteger r, out BigInteger s)
        {
            BigInteger k, kRev, ret;
            do
            {
                k = CryptoTools.GenerateRandomBigInteger(2, p - 1);
                ret = CryptoTools.EuclidAlgorithm(p - 1, k, out _, out kRev);
            } while (ret != 1);
            
            if (kRev < 0)
                kRev += (p - 1);
        
            r = CryptoTools.ModuloPower(g, k, p);

            BigInteger u = (h - x * r) % (p - 1);
            if (u < 0) u += (p - 1);
            s = (kRev * u) % (p - 1);
        }

        private static BigInteger CalculateHash(BigInteger m)
        {
            return m;
        }

        private static bool CheckSignature(BigInteger m, BigInteger r, BigInteger s, BigInteger p, BigInteger y, BigInteger g)
        {
            BigInteger h = CalculateHash(m);

            return (CryptoTools.ModuloPower(y, r, p) * CryptoTools.ModuloPower(r, s, p)) % p == CryptoTools.ModuloPower(g, h, p);
        }
    }
}
