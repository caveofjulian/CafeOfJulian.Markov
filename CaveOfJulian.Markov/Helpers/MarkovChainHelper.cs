using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace CaveOfJulian.Markov.Helpers
{
    internal static class MarkovChainHelper
    {
        public static bool IsRecurrent(int state, int totalStates, IList<Cycle>)
        {

        }
        public static bool IsTransient(int state, int totalStates, IList<Cycle> cycles)
        {
            if (cycles is null || cycles.Count is 0)
                throw new ArgumentException("No cycles detected.", nameof(cycles));

            if (cycles.Count is 1) return true;

            var cycle = GetCycle(state, cycles);

            // If cycles count is equal to total states, this means all states have its own cycle
            // If vertices count is 1, this means it is only going to itself (and thus recurrent)
            if (cycles.Count == totalStates && cycle.Vertices.Count is 1) return true;

            var vertex = GetVertex(state,cycle);

            if (IsEndState(vertex)) return false;
            if (vertex.Dependencies.Count is 1) return true;


        }

        private static bool IsEndState(Vertex vertex)
        {
            return vertex.Dependencies.Count == 0;
        }

        private static Cycle GetCycle(int vertexId, IList<Cycle> cycles)
        {
            foreach (var cycle in cycles)
            {
                foreach (var vertex in cycle.Vertices)
                {
                    if (vertex.Id == vertexId) return cycle;
                }
            }

            return null;
        }

        private static Vertex GetVertex(int id, Cycle cycle)
        {
            foreach (var vertex in cycle.Vertices)
            {
                if (vertex.Id == id) return vertex;
            }

            return null;
        }
        private static Vertex GetVertex(int id, IList<Cycle> cycles)
        {
            foreach (var cycle in cycles)
            {
                foreach (var vertex in cycle.Vertices)
                {
                    if (vertex.Id == id) return vertex;
                }
            }

            return null;
        }
    }
}
