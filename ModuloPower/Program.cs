using System;
using System.Numerics;

namespace ModuloPower
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Result is {0}", CryptoTools.ModuloPower(3, 3, 10));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            
        }
    }
}
