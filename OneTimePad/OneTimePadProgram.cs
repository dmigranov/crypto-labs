using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    static class OneTimePadProgram
    {
        
        static void Main()
        {
            int n = AskForIntInput("Please enter n, n > 0", x => x > 0);
            do
            {
                BigInteger m = AskForBigIntegerInput($"Please enter message, 0 <= m < 2^n = {BigInteger.Pow(2, n)}", x => (x >= 0 && x < BigInteger.Pow(2, n)));
                /*byte[] a = m.ToByteArray(true, true);
                string s = Convert.ToString(a[0], 2).PadLeft(n % 8 != 0 ? n % 8 : 8, '0');
                for(int i = 1; i < (n % 8 == 0 ? n/8 : n/8 + 1); i++)
                {
                    if (i < a.Length)
                        s += Convert.ToString(a[i], 2).PadLeft(8, '0');

                }*/
                string str = m.ToBinaryString();
                str = str.PadLeft(n, '0');
                Console.WriteLine($"Your message is {str}");
                //OneTimePadTools.SendMessage(n, m);
            }
            while (true);
        }

        private static int AskForIntInput(string message, Predicate<int> cond)
        {
            int x;

        Cycle:
            Console.WriteLine(message);
            string s = Console.ReadLine();
            try
            {
                x = int.Parse(s);
                if (!cond(x))
                    goto Cycle;
            }
            catch (FormatException)
            {
                goto Cycle;
            }

            return x;
        }

        private static BigInteger AskForBigIntegerInput(string message, Predicate<BigInteger> cond)
        {
            BigInteger x;

        Cycle:
            Console.WriteLine(message);
            string s = Console.ReadLine();
            try
            {
                x = BigInteger.Parse(s);
                if (!cond(x))
                    goto Cycle;
            }
            catch (FormatException)
            {
                goto Cycle;
            }

            return x;
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
