using System;
using System.Numerics;

namespace Crypto
{
    class CryptoTools
    {
        public static BigInteger ModuloPower(BigInteger val, BigInteger exp, BigInteger mod)
        {
            if (exp < 0 || mod < 0)
                throw new ArgumentException("Negative modulo or exponent");
            BigInteger rem, result = 1, cur = val;
            while(exp > 0)
            {
                rem = exp % 2;
                exp = exp / 2;

                if (rem != 0)
                { 
                    result = (cur * result) % mod;
                }
                cur = (cur * cur) % mod;
            }
            return result;
        }

        public static BigInteger EuclidAlgorithm(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (b > a)
            {
                BigInteger t;
                t = a;
                a = b;
                b = t;
            }

            Triplet prev = new Triplet(a, 1, 0);
            Triplet cur = new Triplet(b, 0, 1);
            Triplet temp;

            while(cur.X != 0)
            {
                temp = cur;
                cur = prev - (prev.X / cur.X) * cur;
                prev = temp;
            }

            x = prev.Y;
            y = prev.Z;
            return prev.X;
        }

        private struct Triplet
        {
            public BigInteger X { get; set; }
            public BigInteger Y { get; set; }
            public BigInteger Z { get; set; }
            public Triplet (BigInteger x, BigInteger y, BigInteger z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public static Triplet operator -(Triplet a, Triplet b)
            {
                return new Triplet(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }
            public static Triplet operator *(BigInteger k, Triplet a)
            {
                return new Triplet(a.X * k, a.Y * k, a.Z * k);
            }
            public static Triplet operator *(Triplet a, BigInteger k)
            {
                return new Triplet(a.X * k, a.Y * k, a.Z * k);
            }
        }

    }
}
