using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    /// <summary>
    /// A cycle is a strongly connected component.
    /// </summary>
    internal class Cycle
    {
        internal List<Vertex> Vertices; 

        public Cycle(List<Vertex> vertices)
        {
            Vertices = vertices;
        }
    }
}
