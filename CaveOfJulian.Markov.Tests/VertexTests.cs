using System;
using System.Collections.Generic;
using System.Text;
using CaveOfJulian.Markov.Extensions;
using CaveOfJulian.Markov.Tests.Input.cs;
using Xunit;

namespace CaveOfJulian.Markov.Tests
{
    public class VertexTests
    {
        [ClassData(typeof(VertexInput))]
        [Theory]
        void Is_Vertex_EndState_Succeeds(Vertex vertex, bool expected)
        {
            var actual = vertex.IsEndState();
            Assert.Equal(expected,actual);
        }
    }
}
