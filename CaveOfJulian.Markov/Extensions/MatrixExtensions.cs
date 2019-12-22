using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace CaveOfJulian.Markov.Extensions
{
    public static class MatrixExtensions
    {
        private static CycleDetector _detector = null;

        public static bool IsRecurrent(this Matrix<double> matrix)
        {
            if (_detector is null)
            {
                _detector = new CycleDetector(matrix);
            }
            else if (_detector.Matrix.Equals(matrix))
            {
                
            }
        }

        public static bool IsTransient(this Matrix<double> matrix)
        {

        }

        public static bool ContainsNegativeValue(this Matrix<double> matrix)
        {
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    if (matrix[i, j] < 0) return true;
                }
            }
            return false;
        }
    }
}
