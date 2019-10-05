using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class PokerTools
    {
        internal static void SimulatePokerExchange(BigInteger p)
        {
            BigInteger cA, dA, cB, dB;
            GeneratePokerPrivateKeys(p, out cA, out dA);
            Console.WriteLine($"Alice's private keys are cA = {cA} and dA = {dA}");
            GeneratePokerPrivateKeys(p, out cB, out dB);
            Console.WriteLine($"Alice's private keys are cB = {cB} and dB = {dB}");

            BigInteger alpha, beta, gamma; //карты
        }

        private static void GeneratePokerPrivateKeys(BigInteger p, out BigInteger c, out BigInteger d)
        {
            BigInteger cCandidate, dCandidate, ret, temp;
            do
            {
                cCandidate = CryptoTools.GenerateRandomBigInteger(1, p - 1);
                ret = CryptoTools.EuclidAlgorithm(p - 1, cCandidate, out temp, out dCandidate);
            } while (ret != 1); //крутимся пока не найдём такое cCandidate: (cCandidate, p - 1) = 1. тогда dCandidate обратное к cCandidate с точностью до модуля
            c = cCandidate;
            if (dCandidate < 0)
                dCandidate += (p - 1);
            d = dCandidate;
        }

    }
}
