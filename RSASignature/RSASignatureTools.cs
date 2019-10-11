using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class RSASignatureTools
    {
        internal static void SimulateRSASigning(BigInteger p, BigInteger q, BigInteger d, BigInteger m)
        {
            Console.WriteLine($"Alice gonna sign messsage m = {m} and send it to Bob");


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
                    ret = CryptoTools.EuclidAlgorithm(phi, dCandidate, out temp, out cCandidate);
                } while (ret != 1);
                c = cCandidate;
                d = dCandidate;
            }
            if (c < 0)
                c += phi;

            Console.WriteLine($"Alice's public keys are N = {N} and d = {d}");
            Console.WriteLine($"Alice's private key is c = {c}");


            BigInteger y = m;
            Console.WriteLine($"Hash function of message {m} is {y} (h(m) = m)");

            BigInteger s = CryptoTools.ModuloPower(y, c, N);
            Console.WriteLine($"Alcie sent message {m} and signature {s} to Bob");


            BigInteger w = CryptoTools.ModuloPower(s, d, N);
            Console.WriteLine("Bob received them and checked if signature is correct");
            if(w == m)
                Console.WriteLine("Signature is correct!");
            else
                Console.WriteLine("Signature is not correct!");

        }

    }
}
