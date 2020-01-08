using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace CaveOfJulian.Markov.Helpers
{
    internal static class MarkovChainHelper
    {
        internal static bool IsRecurrent(int state, int totalStates, IEnumerable<Cycle> cycles)
        {
            return !IsTransient(state,totalStates,cycles);
        }

        internal static bool IsTransient(int state, int totalStates, IEnumerable<Cycle> cycles)
        {
            if (cycles is null || cycles.Count() is 0)
                throw new ArgumentException("No cycles detected.", nameof(cycles));

            if (cycles.Count() is 1) return true;

            var cycle = GetCycle(state, cycles);

            // If cycles count is equal to total states, this means all states have its own cycle
            // If vertices count is 1, this means it is only going to itself (and thus recurrent)
            if (cycles.Count() == totalStates && cycle.Vertices.Count is 1) return true;

            var vertex = GetVertex(state,cycle);

            if (IsEndState(vertex)) return false;
            if (vertex.Successors.Count is 1) return true;

            if (cycle.HasOutgoingNode()) return true;
            
            throw new NotImplementedException();
        }

        private static bool IsTransient(int state, Cycle cycle)
        {
            throw new NotImplementedException();
        }

        private static bool HasOutgoingNode(this Cycle cycle)
        {
            foreach (var vertex in cycle.Vertices)
            {
                foreach (var successor in vertex.Successors)
                {
                    if (!cycle.Vertices.Contains(successor)) return true;
                }
            }

            return false;
        }

        private static bool IsEndState(Vertex vertex)
        {
            return vertex.Successors.Count == 0;
        }

        private static Cycle GetCycle(int vertexId, IEnumerable<Cycle> cycles)
        {
            foreach (var cycle in cycles)
            {
                if (cycle.Vertices.Any(vertex => vertex.Id == vertexId))
                {
                    return cycle;
                }
            }

            return null;
        }

        private static Vertex GetVertex(int id, Cycle cycle)
        {
            return cycle.Vertices.FirstOrDefault(vertex => vertex.Id == id);
        }

        private static Vertex GetVertex(int id, IEnumerable<Cycle> cycles)
        {
            return cycles.SelectMany(cycle => cycle.Vertices).FirstOrDefault(vertex => vertex.Id == id);
        }
    }
}
