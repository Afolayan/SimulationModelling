using System;

namespace Math.RNG.LCG
{
    public class Random : RNG.Random
    {
        protected long a, c; // m: modulus

        public Random()
            : base()
        {
            a = 5;
            m = (long)System.Math.Pow(2, 4);
            c = 3;
        }

        public Random(long seed)
            : base(seed)
        {
            a = 5;
            m = (long)System.Math.Pow(2, 4);
            c = 3;
        }

        /// <summary>
        /// construct mixed LCG
        /// </summary>
        /// <param name="seed">seed</param>
        /// <param name="a">multiplier</param>
        /// <param name="m">modulus</param>
        /// <param name="c">increment</param>
        public Random(long seed, long a, long m, long c)
            : base(seed)
        {
            this.a = a;

            this.m = m;

            this.c = c;

            // c is odd; a - 1 is divisible by 4; seed is any integer between 0 and m - 1

            // test c is odd
            if ((c % 2) != 1)
            {
                ;
            }

            // test a - 1 is divisible by 4

            // test seed is any integer between 0 and m - 1
        }

        public override long Next()
        {
            seed = ((a * seed) + c) % m;
            return seed;
        }

        public override void NextBytes(byte[] b)
        {
            throw new NotImplementedException();
        }
    }
}