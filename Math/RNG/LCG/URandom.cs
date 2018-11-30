using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG.LCG
{
    public class URandom : RNG.URandom
    {
        public URandom()
            : base(new Random()) { }

        public URandom(RNG.Random r)
            : base(r) { }

        public URandom(long seed)
            : base(new Random(seed)) { }

        public URandom(long seed, long a, long b, long c)
            : base(new Random(seed, a, b, c)) { }

        /// <summary>
        /// implements only the uniform distribuion
        /// </summary>
        /// <returns></returns>
        protected override object Sample()
        {
            object o = null;

            switch (d)
            {
                case Enums.Distribution.Bernoulli:
                    break;

                case Enums.Distribution.Beta:
                    break;

                case Enums.Distribution.Bezier:
                    break;

                case Enums.Distribution.Binomial:
                    break;

                case Enums.Distribution.Exponential:
                    break;

                case Enums.Distribution.Gamma:
                    break;

                case Enums.Distribution.Geometric:
                    break;

                case Enums.Distribution.JohnsonBounded:
                    break;

                case Enums.Distribution.JohnsonUnbounded:
                    break;

                case Enums.Distribution.LogLogistic:
                    break;

                case Enums.Distribution.LogNormal:
                    break;

                case Enums.Distribution.mErlang:
                    break;

                case Enums.Distribution.NegativeBinomial:
                    break;

                case Enums.Distribution.Normal:
                    break;

                case Enums.Distribution.Pearson5:
                    break;

                case Enums.Distribution.Pearson6:
                    break;

                case Enums.Distribution.Poisson:
                    break;

                case Enums.Distribution.Triangular:
                    break;

                // continuous uniform a: lowerlimit; b: upperlimit
                case Enums.Distribution.Uniform_Cont:
                    double n = r.NextDouble();
                    o = a + (n * (b - a));
                    break;

                case Enums.Distribution.Uniform_Disc:
                    break;

                case Enums.Distribution.Weibull:
                    break;
            }

            return o;
        }
    }
}