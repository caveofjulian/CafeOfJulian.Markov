using System;
using System.Collections.Generic;
using System.Text;
using CaveOfJulian.Markov.Helpers;
using MathNet.Numerics.LinearAlgebra;

namespace CaveOfJulian.Markov.Extensions
{
    public static class MatrixExtensions
    {
        private static CycleDetector _detector;
        
        public static bool IsEndState(this Matrix<double> matrix, int state)
        {
            for (var i = 0; i < matrix.ColumnCount; i++)
            {
                if (matrix[state, i] > 0) return false;
            }
            
            return true;
        }

        public static bool IsRecurrent(this Matrix<double> matrix, int state)
        {
            if (matrix.IsEndState(state)) return false;

            if (matrix.RowCount is 1) return matrix[state,state] is 1;

            if (_detector is null)
            {
                _detector = new CycleDetector(matrix);
            }
            else if (_detector.Matrix.Equals(matrix))
            {
                return MarkovChainHelper.IsRecurrent(state, matrix.RowCount, _detector.Cycles);
            }

            _detector.
        }

        public static bool IsTransient(this Matrix<double> matrix, int state)
        {
            if (matrix.IsEndState(state)) return true;

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
