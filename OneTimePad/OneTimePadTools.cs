using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Crypto
{
    static class OneTimePadTools
    {

        internal static void SendMessage(int n, BigInteger msg)
        {
            
            Console.WriteLine("Your message is:");
            Console.WriteLine(msg.ToPaddedBinaryString(n));

            BigInteger k = GenerateKey(n);
            Console.WriteLine($"Secret key k = {k} generated. Binary is:");
            Console.WriteLine(k.ToPaddedBinaryString(n));

        }

        private static BigInteger GenerateKey(int n)
        {
            return CryptoTools.GenerateUnsignedRandomBigInteger(0, BigInteger.Pow(2, n));
        }


        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray(true, false);
            var idx = bytes.Length - 1;

            var base2 = new StringBuilder(bytes.Length * 8);

            var binary = Convert.ToString(bytes[idx], 2);

            base2.Append(binary);

            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }

        public static string ToPaddedBinaryString(this BigInteger bigint, int n)
        {
            string str = bigint.ToBinaryString();
            return str.PadLeft(n, '0');
        }
    }
}
