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

            if(args.Length > 0)
            {
                p = BigInteger.Parse(args[0]);
                if (args.Length > 1)
                    g = BigInteger.Parse(args[1]);
                else Console.WriteLine("Only one argument, g = 2 will be used");
            }
            else Console.WriteLine("No arguments, p = 30803, g = 2 will be used");

            SimulateDiffieHellmanKeyExchange(p, g);

        }

        private static void SimulateDiffieHellmanKeyExchange(BigInteger p, BigInteger g)
        {
            Console.WriteLine("Alice starts exchange");

            BigInteger xA = CryptoTools.GenerateDiffieHellmanPrivateKey(g, p);
            Console.WriteLine("Alice generated private key xA = {0}", xA);
            BigInteger yA = CryptoTools.GenerateDiffieHellmanPublicKey(g, xA, p);
            Console.WriteLine("Alice generated public key yA = {0} and sent it to Bob", yA);

            BigInteger xB = CryptoTools.GenerateDiffieHellmanPrivateKey(g, p);
            Console.WriteLine("Bob generated private key xB = {0}", xB);
            BigInteger yB = CryptoTools.GenerateDiffieHellmanPublicKey(g, xB, p);
            Console.WriteLine("Bob generated public key yB = {0} and sent it to Alice", yB);




        }
    }
}
