using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    internal class Rnd : IStochastic
    {
        private Random _rnd;

        public Rnd()
        {
            _rnd = new Random();
        }

        /// <summary>
        /// Returns a random floating-point number that is great than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <returns></returns>
        public double NextDouble()
        {
            return _rnd.NextDouble();
        }
    }
}
