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
            Console.WriteLine($"Alice encrypted card numbers: alpha to {encryptedCardsForBob.X}, beta to {encryptedCardsForBob.Y}, gamma to {encryptedCardsForBob.Z}...");
            encryptedCardsForBob.Mix();
            Console.WriteLine($"...And then mixed them: {encryptedCardsForBob.X}, {encryptedCardsForBob.Y}, {encryptedCardsForBob.Z} and sent to Bob");

            BigInteger cardAEncryptedNumber = encryptedCardsForBob.ChooseRandom3();
            Console.WriteLine($"Bob chose {cardAEncryptedNumber} and sent to Alice");

            BigInteger cardANumber = CryptoTools.ModuloPower(cardAEncryptedNumber, dA, p);
            Console.WriteLine($"Alice decrypted it; her card number is {cardANumber} and it's {cards.FindName(cardANumber)}!");

            encryptedCardsForBob.RemoveUsedCard();
            Triplet encryptedCardsForAlice = encryptedCardsForBob.ModuloPower(cB, p);
            encryptedCardsForAlice.Mix();
            Console.Write($"Bob encrypted card numbers, mixed them and sent to Alice: ");
            for(int i = 0; i < 3; i++) if (encryptedCardsForAlice[i].Number != 0) Console.Write($"{encryptedCardsForAlice[i].Name} to {encryptedCardsForAlice[i].Number} ");
            Console.WriteLine();

            BigInteger cardBEncryptedNumber = encryptedCardsForAlice.ChooseRandom2();
            BigInteger cardBPartiallyDecryptedNumber = CryptoTools.ModuloPower(cardBEncryptedNumber, dA, p);

            Console.WriteLine($"Alice chose {cardBEncryptedNumber}, found its power {cardBPartiallyDecryptedNumber} and sent to Bob");

            BigInteger cardBNumber = CryptoTools.ModuloPower(cardBPartiallyDecryptedNumber, dB, p);
            Console.WriteLine($"Bob decrypted it; his card number is {cardBNumber} and it's {cards.FindName(cardBNumber)}!");

            encryptedCardsForBob.RemoveUsedCard();
            for (int i = 0; i < 3; i++) 
                if (cards[i].Number != cardANumber && cards[i].Number != cardBNumber) Console.WriteLine($"The third card has number {cards[i].Number} and is {cards[i].Name} ");


        }

        private class Triplet
        {
            private int chosenCardIndex;
            public Card A { get; set; }
            public Card B { get; set; }
            public Card C { get; set; }

            public BigInteger X { get => A.Number; set => A.Number = value; }
            public BigInteger Y { get => B.Number; set => B.Number = value; }
            public BigInteger Z { get => C.Number; set => C.Number = value; }

            public Triplet(Card a, Card b, Card c)
            {
                chosenCardIndex = -1;
                A = a;
                B = b;
                C = c;
            }

            public Triplet ModuloPower(BigInteger exp, BigInteger mod)
            {
                return new Triplet(Card.ModuloPower(A, exp, mod), Card.ModuloPower(B, exp, mod), Card.ModuloPower(C, exp, mod));
            }

            public string FindName(BigInteger cardNumber)
            {
                    if (X == cardNumber)
                        return A.Name;
                    else if (Y == cardNumber)
                        return B.Name;
                    else return C.Name;
            }

            public Card this[int index]
            {
                get
                {
                    if (0 == index)
                        return A;
                    else if (1 == index)
                        return B;
                    else return C;
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

            internal BigInteger ChooseRandom3()
            {
                int i = r.Next(0, 3);
                chosenCardIndex = i;
                return this[i].Number;
            }

            internal void RemoveUsedCard()
            {
                this[chosenCardIndex].Number = 0;
            }

            internal BigInteger ChooseRandom2()
            {
                int i;
                do
                    i = r.Next(0, 3);
                while (this[i].Number == 0);

                chosenCardIndex = i;
                return this[i].Number;
            }
        }


        private class Card
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
