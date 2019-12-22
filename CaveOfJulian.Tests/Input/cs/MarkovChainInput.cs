using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CaveOfJulian.Markov;

namespace CaveOfJulian.Tests.Input.cs
{
    public class NormalizeSuccessInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[]
            {
                new [,]
                {
                    {1,0,0,0},
                    {25,25,25,25 },
                    {0,0d,0,0 },
                },
                new [,]
                {
                    {1,0,0,0 },
                    {0.25,0.25,0.25,0.25 },
                    {0,0,0,0 },
                }, 

            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class NormalizeNegativeInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[]
            {
                new double[,]
                {
                    {-1,0,0,0},
                    {-25,-25,-25,-25 },
                },

            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
