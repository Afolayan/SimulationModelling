using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.RNG
{
    public abstract class Random
    {
        protected long m;

        protected long seed = DateTime.Now.Ticks;

        public Random() { }

        public Random(long seed)
        {
            this.seed = seed;
        }

        /// <summary>
        /// next random integer between 0 and modulus
        /// </summary>
        /// <returns></returns>
        public abstract long Next();

        /// <summary>
        /// next random integer less than an upper limit
        /// </summary>
        /// <param name="upp">upper limit</param>
        /// <returns>next random integer</returns>
        public long Next(long upp)
        {
            return Next(0, upp);
        }

        /// <summary>
        /// next random integer between a lower limit and an upper limit
        /// </summary>
        /// <param name="lwr">lower limit</param>
        /// <param name="upp">upper limit</param>
        /// <returns>next random integer</returns>
        public long Next(long lwr, long upp)
        {
            return (long)(lwr + (Sample() * (upp - lwr)));
        }

        public abstract void NextBytes(byte[] b);

        /// <summary>
        /// next random number between 0 and 1
        /// </summary>
        /// <returns>next random number</returns>
        public double NextDouble()
        {
            return Sample();
        }

        /// <summary>
        /// next random number between 0 and 1
        /// </summary>
        /// <returns>next random number</returns>
        public virtual double Sample()
        {
            return ((double)Next() / m);
        }
    }
}