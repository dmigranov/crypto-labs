using System;
using System.Linq;
using System.Numerics;
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
                byte[] a = m.ToByteArray();

                /*string selector(byte x)
                {
                    return Convert.ToString(x, 2).PadLeft(8, '0');
                }


                string s = string.Join(" ", a.Reverse().Select(selector));*/

                string s = Convert.ToString(a[0], 2).PadLeft(n % 8 != 0 ? n % 8 : 8, '0');
                for(int i = 1; i < a.Length; i++)
                {
                    s += Convert.ToString(a[i], 2).PadLeft(8, '0');
                }
                
                Console.WriteLine($"Your message is {s}");
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
    }
}
