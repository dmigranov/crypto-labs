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
                Console.WriteLine($"d = {d} you provided isn't mutually prime with phi(N)! A new one will be generated");

            }
            if (c < 0)
                c += phi;
            //todo: генерация как в шамире если не получилось?
            Console.WriteLine($"Receiver's public keys are N = {N} and d = {d}");
            Console.WriteLine($"Receiver's private key is c = {c}");


            BigInteger y = CryptoTools.ModuloPower(x, d, N);
            Console.WriteLine($"Sender encrypted message and sent y = {y} to receiver");

            BigInteger w = CryptoTools.ModuloPower(y, c, N);
            Console.WriteLine($"Receiver decrypted y and got w = {w}");
        }
    }
}