using System;

namespace ModuloPower
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Result is {0}", CryptoTools.ModuloPower(2, 0, 10));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            
        }
    }
}
