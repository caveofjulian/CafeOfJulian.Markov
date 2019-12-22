using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CafeOfJulian.Benchmarks
{
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [RPlotExporter]
    public class ContainsNegativeValueBenchmark
    {
        private HashSet<double> _index;

        public Matrix<double> matrix => Matrix<double>.Build.DenseOfArray(new double[,]
        {
            {3}, {4}, {23423}, {-1231}, {4}, {23423}, {-1231}, {4}, {23423}, {-1231}, {4}, {23423}, {-1231},
            {4}, {23423}, {-1231}, {4}, {23423}, {-1231}, {4}, {23423}, {-1231}, {4}, {23423}, {-1231}, {4}, {23423},
            {-1231}, {4}, {23423}, {-1231}
        });

        [Benchmark]
        public bool ContainsValueHashSet()
        {
            if(_index is null)
                _index = new HashSet<double>();
                
            for (int i = 0; i < matrix.RowCount; i++)
                {
                    for (int j = 0; j < matrix.ColumnCount; j++)
                    {
                        _index.Add(matrix[i, j]);
                    }
                }
            
            return _index.Contains(5);
        }

        [Benchmark]
        public bool ContainsValue()
        {
            for (var i = 0; i < matrix.RowCount; i++)
            {
                for (var j = 0; j < matrix.ColumnCount; j++)
                {
                    if (matrix[i, j] is 5) return true;
                }
            }
            return false;
        }
    }
}
