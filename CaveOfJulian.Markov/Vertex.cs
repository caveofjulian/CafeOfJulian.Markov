using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    internal class Vertex
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public int Lowlink { get; set; }

        public HashSet<Vertex> Dependencies { get; set; }

        public Vertex()
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
            Dependencies = new HashSet<Vertex>();
        }
    }
}
