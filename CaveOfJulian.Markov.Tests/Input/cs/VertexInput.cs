using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Markov.Tests.Input.cs
{
    public class VertexInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Vertex(),
                true
            };
            yield return new object[]
            {
                new Vertex()
                {
                    Successors = new HashSet<Vertex>(new []{new Vertex(), })
                },
                false
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
