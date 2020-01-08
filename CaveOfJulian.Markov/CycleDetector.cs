using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    /// <summary>
    /// Detects strongly connected components and stores it as a cycle.
    /// </summary>
    internal class CycleDetector
    {
        internal readonly Matrix<double> Matrix;
        internal List<Cycle> Cycles { get; private set; }
        private Stack<Vertex> _stack;
        private int _index = -1;

        internal CycleDetector(Matrix<double> matrix)
        {
            Matrix = matrix;
        }

        internal List<Cycle> DetectCycles()
        {
            Cycles = new List<Cycle>();
            var graph = CreateVertices(Matrix);

            _index = 0;
            _stack = new Stack<Vertex>();

            foreach (var vertex in graph)
            {
                if (vertex.Index is -1)
                {
                    StronglyConnect(vertex);
                }
            }

            return Cycles;
        }

        private IList<Vertex> CreateVertices(Matrix<double> graphNodes)
        {
            var list = new List<Vertex>();

            for (var i = 0; i < graphNodes.RowCount; i++)
            {
                list.Add(new Vertex()
                {
                    Id = i
                });   
            }

            for (var i = 0; i < graphNodes.RowCount; i++)
            {
                list[i].Successors = new HashSet<Vertex>();

                for (var j = 0; j < graphNodes.ColumnCount; j++)
                {
                    if (graphNodes[i, j] > 0)
                    {
                        list[i].Successors.Add(list[j]);
                    }
                }
            }

            return list;
        }

        private void StronglyConnect(Vertex vertex)
        {
            vertex.Index = _index;
            vertex.LowLink = _index;

            _index++;
            _stack.Push(vertex);

            foreach (var dependency in vertex.Successors)
            {
                if (dependency.Index is -1)
                {
                    StronglyConnect(dependency);
                    vertex.LowLink = Math.Min(vertex.LowLink, dependency.LowLink);
                }
                else if (_stack.Contains(dependency))
                {
                    vertex.LowLink = Math.Min(vertex.LowLink, dependency.Index);
                }
            }

            if (vertex.LowLink == vertex.Index)
            {
                AddCycle(vertex);
            }
        }

        private void AddCycle(Vertex vertex)
        {
            var cycle = new List<Vertex>();
            Vertex v;

            do
            {
                v = _stack.Pop();
                cycle.Add(v);
            } while (vertex != v);

            Cycles.Add(new Cycle(cycle));
        }
    }
}
