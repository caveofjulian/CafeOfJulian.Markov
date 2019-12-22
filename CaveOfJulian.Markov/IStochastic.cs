using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    public interface IStochastic
    {
        /// <summary>
        /// Returns a random floating-point number that is great than or equal to 0.0, and less than 1.0.
        /// </summary>
        /// <returns></returns>
        double NextDouble();
    }
}
