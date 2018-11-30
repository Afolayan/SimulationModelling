using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG
{
    namespace Enums
    {
        public enum Distribution
        {
            // continuous
            Beta, Bezier, Exponential, Gamma, JohnsonBounded, JohnsonUnbounded, LogLogistic,
            LogNormal, mErlang, Normal, Pearson5, Pearson6, Triangular, Uniform_Cont, Weibull,
            // discrete
            Bernoulli, Binomial, Geometric, NegativeBinomial, Poisson, Uniform_Disc
        }
    }
}