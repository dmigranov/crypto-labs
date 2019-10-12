using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Crypto
{


    internal class NumberIndex : IComparable<NumberIndex>
    {

        public BigInteger Number { get; set; }
        public BigInteger Index { get; set; }
        public bool IsBaby { get; } //0 Baby 1 Giant

        public NumberIndex(BigInteger number, BigInteger index, bool isBaby)
        {
            Number = number;
            Index = index;
            IsBaby = isBaby;
        }


        public int CompareTo([AllowNull] NumberIndex other)
        {
            if (this.Number > other.Number)
                return 1;
            if (this.Number < other.Number)
                return -1;
            else
                return 0;
        }
    }

    internal class BSGSTools
    {
        //private static List<NumberIndex> babyList = new List<NumberIndex>(), giantList = new List<NumberIndex>();

        internal static BigInteger SolveEquation(BigInteger y, BigInteger a, BigInteger p)
        {
            List<NumberIndex> commonList = new List<NumberIndex>();

            BigInteger k, m;
            k = m = (BigInteger)Math.Ceiling(Math.Sqrt((double)p));
            for (BigInteger i = 0; i < m; i++)
            {
                commonList.Add(new NumberIndex((y * CryptoTools.ModuloPower(a, i, p)) % p, i, true));
            }

            for (BigInteger j = 1; j <= k; j++)
            {
                commonList.Add(new NumberIndex(CryptoTools.ModuloPower(a, j * m, p), k, false));
            }

            commonList.Sort();

            NumberIndex prev = null, cur = null;
            BigInteger iX = 0, jX = 0;
            foreach(var element in commonList)
            {
                if(cur != null)
                    prev = cur;
                cur = element;

                if (prev != null)
                    if (prev.Number == cur.Number)
                    {
                        if (prev.IsBaby != cur.IsBaby)
                        {
                            if (prev.IsBaby == true)
                            {
                                iX = prev.Index;
                                jX = cur.Index;
                            }
                            else
                            {
                                jX = prev.Index;
                                iX = cur.Index;
                            }
                            break;
                        }
                        else
                        {

                        }
                    }
            }

            return iX * m - jX;

        }
    }
}