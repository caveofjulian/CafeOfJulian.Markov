using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Tests.Input.cs
{
    public class AbsorbingStatesInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new [,]
                {
                    {1d}
                },
                true
            };
            yield return new object[]
            {
                new [,]
                {
                    {0.1}
                },
                false
            };
            yield return new object[]
            {
                new [,]
                {
                    {0.0}
                },
                false
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
