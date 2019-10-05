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
            Triplet cards = new Triplet(new Card(alpha, "ALPHA"), new Card(beta, "BETA"), new Card(gamma, "GAMMA"));
            Triplet encryptedCardsForBob = cards.ModuloPower(cA, p);
            Console.WriteLine($"Alice encrypted card numbers: alpha to {encryptedCardsForBob.X}, beta is {encryptedCardsForBob.Y}, gamma is {encryptedCardsForBob.Z}...");
            encryptedCardsForBob.Mix();
            Console.WriteLine($"...And then mixed them: {encryptedCardsForBob.X}, {encryptedCardsForBob.Y}, {encryptedCardsForBob.Z} and sent to Bob");

            BigInteger cardAEncryptedNumber = encryptedCardsForBob.ChooseRandom(3);
            Console.WriteLine($"Bob chose {cardAEncryptedNumber} and sent to Alice");

            BigInteger cardANumber = CryptoTools.ModuloPower(cardAEncryptedNumber, dA, p);
            Console.WriteLine($"Alice decrypted it; her card number is {cardANumber} and it's {cards[cardANumber]}!");



            Triplet cardsForAlice = new Triplet(encryptedCardsForBob.A, encryptedCardsForBob.B, encryptedCardsForBob.C);
        }

        private struct Triplet
        {
            public Card A { get; set; }
            public Card B { get; set; }
            public Card C { get; set; }

            public BigInteger X { get => A.Number; }
            public BigInteger Y { get => B.Number; }
            public BigInteger Z { get => C.Number; }

            public Triplet(Card a, Card b, Card c)
            {
                A = a;
                B = b;
                C = c;
            }


            public Triplet ModuloPower(BigInteger exp, BigInteger mod)
            {
                return new Triplet(Card.ModuloPower(A, exp, mod), Card.ModuloPower(B, exp, mod), Card.ModuloPower(C, exp, mod));
            }

            public string this[BigInteger index]
            {
                get
                {
                    if (X == index)
                        return A.Name;
                    else if (Y == index)
                        return B.Name;
                    else return C.Name;
                }
            }

            public void Mix()
            {

                List<Card> old = new List<Card>();
                old.Add(A); old.Add(B); old.Add(C);


                int aI = r.Next(0, 3);
                A = old[aI];
                old.RemoveAt(aI);

                int bI = r.Next(0, 2);
                B = old[bI];
                C = old[1 - bI];
            }

            internal BigInteger ChooseRandom(int of)
            {
                int i = r.Next(0, of);
                if (i == 0)
                    return X;
                else if (i == 1)
                    return Y;
                else return Z;
                
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

            public static Card ModuloPower(Card a, BigInteger exp, BigInteger mod)
            {
                return new Card(CryptoTools.ModuloPower(a.Number, exp, mod), a.Name);
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
