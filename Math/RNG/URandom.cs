using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG
{
    public abstract class URandom
    {
        protected Enums.Distribution d;
        protected double? a, b, m, p, s, t;
        protected double? alpha1, alpha2, beta, lambda, mu, sigma;
        protected int? i, j;

        protected Random r;

        public URandom(Random r)
        {
            this.r = r;
        }

        public object Next()
        {
            return Sample();
        }

        protected abstract object Sample();

        public URandom SetParameters(Enums.Distribution d, double? a, double? b, int? i, int? j, double? m,
            double? p, double? s, double? t, double? alpha1, double? alpha2, double? beta, double? lambda,
            double? mu, double? sigma)
        {
            this.d = d; this.a = a; this.b = b; this.i = i; this.j = j; this.m = m;
            this.p = p; this.s = s; this.t = t;
            this.alpha1 = alpha1;
            this.alpha2 = alpha2;
            this.beta = beta;
            this.lambda = lambda;
            this.mu = mu;
            this.sigma = sigma;

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
                    if ((a == null) || (b == null))
                        throw new ArgumentException();
                    break;
                case Enums.Distribution.Uniform_Disc:
                    break;
                case Enums.Distribution.Weibull:
                    break;
            }

            return this;
        }
    }
}
