using System;

namespace Math.RNG.LCG
{
    public class Basic : Random
    {
        protected long a, b, c; // m: modulus

        public Basic()
            : base()
        {
            a = 5;
            b = 4;
            m = (long)System.Math.Pow(2, b);
            c = 3;
        }

        public Basic(long seed)
            : base(seed)
        {
            a = 5;
            b = 4;
            m = (long)System.Math.Pow(2, b);
            c = 3;
        }

        /// <summary>
        /// construct mixed LCG
        /// </summary>
        /// <param name="seed">seed</param>
        /// <param name="a">multiplier</param>
        /// <param name="b">number of bits</param>
        /// <param name="c">increment</param>
        public Basic(long seed, long a, long b, long c)
            : base(seed)
        {
            this.a = a;

            this.b = b;
            m = (long)System.Math.Pow(2.0, b);

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