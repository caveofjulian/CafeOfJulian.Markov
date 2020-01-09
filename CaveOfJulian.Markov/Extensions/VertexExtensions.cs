using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov.Extensions
{
    internal static class VertexExtensions
    {
        public static bool IsEndState(this Vertex vertex)
        {
            return vertex.Successors.Count == 0;
        }
    }
}
