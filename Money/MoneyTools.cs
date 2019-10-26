using System;
using System.Numerics;
using System.Text;

namespace Crypto
{
    class MoneyTools
    {
        public static void SimulateMoneyExchange(BigInteger p, BigInteger q)
        {
            Console.WriteLine($"Bank's private p is {p}");
            Console.WriteLine($"Bank's private q is {q}");
            BigInteger N = p * q, phi = (p - 1) * (q - 1);
            Console.WriteLine($"Bank's public N is {N}, phi(N) = {phi}");

            BigInteger c, d;
            CryptoTools.GenerateInverseNumbers(phi, out c, out d);
            Console.WriteLine($"Bank's private c is {c} and public d is {d}");

            Console.WriteLine("START OF EXCHANGE");

            BigInteger n = CryptoTools.GenerateRandomBigInteger(2, N);
            BigInteger r, rInv;
            CryptoTools.GenerateInverseNumbers(N, out r, out rInv);
            BigInteger n_ = n * CryptoTools.ModuloPower(r, d, N) % N;

            Console.WriteLine("Client wants to purchase an item.");
            Console.WriteLine($"Client generated private n = {n}, random r = {r}: (r, N) = 1, then calculated n_ = (n * r^d) mod N = {n_} and sent it to bank");

            BigInteger s_ = CryptoTools.ModuloPower(n_, c, N);
            Console.WriteLine($"Bank calculated s_ = {s_}, withdrew money from client's account and sent s_ to client");

            BigInteger s = (s_ * rInv) % N;
            Console.WriteLine($"Client calculated s = {s} - this is bank's signature. Client's banknote is <n = {n}, s = {s}>");

            Console.WriteLine("Client sends banknote to shop");
            Console.WriteLine("Shop checks signature and sends banknote to bank to check if it was used");
            SimulateBanknoteChecking(n, s, d, N);

        }

        private static bool CheckBanknoteSignature(BigInteger n, BigInteger s, BigInteger d, BigInteger N)
        {
            if (n == CryptoTools.ModuloPower(s, d, N))
                return true;
            return false;
        }

        internal static void SimulateBanknoteChecking(BigInteger n, BigInteger s, BigInteger d, BigInteger N)
        {
            if (CheckBanknoteSignature(n, s, d, N) == true)
                Console.WriteLine("Banknote signature is correct! Bank sends money to shop's account, shop gives item to client");
            else
                Console.WriteLine("Banknote signature is not correct!");
        }
    }
}
