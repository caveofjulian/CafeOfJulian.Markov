using System;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov
{
    internal class Vertex
    {
        public int Id { get; set; }
        public int Index { get; set; } = -1;
        public int LowLink { get; set; } = -1;

        public HashSet<Vertex> Successors { get; set; }

        public Vertex()
        {
            Successors = new HashSet<Vertex>();
        }
    }
}
