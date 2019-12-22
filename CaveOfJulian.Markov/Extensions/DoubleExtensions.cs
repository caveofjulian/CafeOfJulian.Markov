using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov.Extensions
{
    public static class DoubleExtensions
    {
        public static bool Equals(this double value, double comparison, double acceptedDifference = 0.005)
        {
            return Math.Abs(value - comparison) < acceptedDifference;
        }
    }
}
