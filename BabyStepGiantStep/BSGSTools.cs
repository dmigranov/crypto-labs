using System;
using System.Collections.Generic;
using System.Numerics;

namespace Crypto
{


    internal class NumberIndex
    {

        public BigInteger Number { get; set; }
        public int Index { get; set; }

        public Boolean IsBaby { get; } //0 Baby 1 Giant




    }

    internal class BSGSTools
    {
        private static List<NumberIndex> babyList = new List<NumberIndex>(), giantList = new List<NumberIndex>();

        internal static void SolveEquation(BigInteger y, BigInteger a, BigInteger p)
        {
            throw new NotImplementedException();
        }
    }
}