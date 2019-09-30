using System;
using System.Numerics;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            string pString;

            if (args.Length == 0)
            {
                Console.WriteLine("No arguments, please enter prime number p:");
                pString = Console.ReadLine();
            }
            else pString = args[0];

            BigInteger p;
            try
            {
                p = BigInteger.Parse(pString);
                //SimulateShamirExchange(p);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }


    }


}

