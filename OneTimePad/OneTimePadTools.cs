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
            string str = msg.ToBinaryString();
            str = str.PadLeft(n, '0');
            Console.WriteLine($"Your message is {str}");

            BigInteger k = GenerateKey(n);
            Console.WriteLine($"Secret key k = {k} generated");

        }

        private static BigInteger GenerateKey(int n)
        {
            return 0;
        }


        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray(true, false);
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            /*if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }*/



            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }
    }
}
