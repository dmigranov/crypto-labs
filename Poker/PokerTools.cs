using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class PokerTools
    {
        private static readonly Random r = new Random();
        internal static void SimulatePokerExchange(BigInteger p)
        {
            BigInteger cA, dA, cB, dB;
            GeneratePokerPrivateKeys(p, out cA, out dA);
            Console.WriteLine($"Alice's private keys are cA = {cA} and dA = {dA}");
            GeneratePokerPrivateKeys(p, out cB, out dB);
            Console.WriteLine($"Bob's private keys are cB = {cB} and dB = {dB}");

            BigInteger alpha, beta, gamma; //карты
            GenerateCardNumbers(p, out alpha, out beta, out gamma);
            Console.WriteLine($"Alice generated numbers for cards and told Bob that alpha is {alpha}, beta is {beta}, gamma is {gamma}");

            Console.WriteLine("START OF THE EXCHANGE");
            Triplet cards = new Triplet(alpha, beta, gamma);
            Triplet encryptedCardsForBob = cards.ModuloPower(cA, p);
            Console.WriteLine($"Alice encrypted card numbers: alpha to {encryptedCardsForBob.X}, beta is {encryptedCardsForBob.Y}, gamma is {encryptedCardsForBob.Z}...");
            encryptedCardsForBob.Mix();
            Console.WriteLine($"...And then mixed them: {encryptedCardsForBob.X}, {encryptedCardsForBob.Y}, {encryptedCardsForBob.Z} and sent to Bob");

            BigInteger cardAEncrypted = encryptedCardsForBob[r.Next(0, 3)];
            Console.WriteLine($"Bob chose {cardAEncrypted} and sent to Alice");

            BigInteger cardA = CryptoTools.ModuloPower(cardAEncrypted, dA, p);
            Console.WriteLine($"Alice decrypted it; her card number is {cardA}!");


        }

        private struct Triplet
        {
            public Card A { get; set; }
            public Card B { get; set; }
            public Card C { get; set; }

            public BigInteger X { get => A.Number; }
            public Triplet(Card a, Card b, Card c)
            {
                A = a;
                B = b;
                C = c;
            }


            public Triplet ModuloPower(BigInteger exp, BigInteger mod)
            {
                return new Triplet(CryptoTools.ModuloPower(A, exp, mod), CryptoTools.ModuloPower(B, exp, mod), CryptoTools.ModuloPower(Z, exp, mod));
            }

            public BigInteger this[int index]
            {
                get
                {
                    if (index == 0)
                        return X;
                    else if (index == 1)
                        return Y;
                    else return Z;
                }
                
            }

            public void Mix()
            {

                List<BigInteger> old = new List<BigInteger>();
                old.Add(X); old.Add(Y); old.Add(Z);

                int xI = r.Next(0, 3);
                X = old[xI];
                old.RemoveAt(xI);

                int yI = r.Next(0, 2);
                Y = old[yI];
                Z = old[1 - yI];
            }
        }


        private struct Card
        {
            public BigInteger Number { get; set; }
            public string Name { get; set; }

            public Card(BigInteger number, string name)
            {
                Number = number;
                Name = name;
            }
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


        private static void GenerateCardNumbers(BigInteger p, out BigInteger a, out BigInteger b, out BigInteger c)
        {
            a = CryptoTools.GenerateRandomBigInteger(1, p);
            do b = CryptoTools.GenerateRandomBigInteger(1, p); while (b == a);
            do c = CryptoTools.GenerateRandomBigInteger(1, p); while (c == a || c == b);
        }
    }
}
