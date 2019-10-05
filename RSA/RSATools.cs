using System;
using System.Numerics;

namespace Crypto
{
    internal class RSATools
    {
        internal static void SimulateRSAExchange(BigInteger p, BigInteger q, BigInteger d, BigInteger x)
        {
            BigInteger N = p * q;
            BigInteger phi = (p - 1) * (q - 1);

            BigInteger c, temp;

            BigInteger ret = CryptoTools.EuclidAlgorithm(phi, d, out temp, out c);
            if (ret != 1)
            {
                Console.WriteLine($"d = {d} isn't mutually prime with phi(N)! A new one will be generated");
                
                BigInteger cCandidate, dCandidate;
                do
                {
                    dCandidate = CryptoTools.GenerateRandomBigInteger(1, phi);
                    ret = CryptoTools.EuclidAlgorithm(p - 1, dCandidate, out temp, out cCandidate);
                } while (ret != 1); 
                c = cCandidate;
                d = dCandidate;
            }
            if (c < 0)
                c += phi;

            Console.WriteLine($"Receiver's public keys are N = {N} and d = {d}");
            Console.WriteLine($"Receiver's private key is c = {c}");

            BigInteger y = CryptoTools.ModuloPower(x, d, N);
            Console.WriteLine($"Sender encrypted message and sent y = {y} to receiver");

            BigInteger w = CryptoTools.ModuloPower(y, c, N);
            Console.WriteLine($"Receiver decrypted y and got w = {w}");
        }
    }
}