using System;
using System.Numerics;

namespace ModuloPower
{
    class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                //Console.Re
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }*/

            BigInteger p = 30803, g = 2;

            if(args.Length < 2)
            {
                if (args.Length == 0)
                {
                    p = 30803;
                    s
                }
            }
            
        }

        private void SimulateDiffieHellmanKeyExchange(BigInteger p, BigInteger g)
        {
            Console.WriteLine("Alice starts exchange");

            BigInteger xA = CryptoTools.GenerateDiffieHellmanPrivateKey(g, p);
            Console.WriteLine("Alice generated private key {0}", xA);
            BigInteger yA = CryptoTools.GenerateDiffieHellmanPublicKey(g, xA, p);
            Console.WriteLine("Alice generated public key {0}", yA);


        }
    }
}
