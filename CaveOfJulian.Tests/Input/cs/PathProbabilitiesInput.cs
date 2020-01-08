using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Tests.Input.cs
{
    public class OneStepTransitionProbabilityInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[,]
                {
                    {0.2,0.25,0.25,0.25,0.05},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.09,0.3,0.3,0.3,0.01},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.2,0.1,0.3,0.15,0.25 },
                },
                4, 
                2,
                0.3
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class OneStepTransitionProbabilityInvalidStartEndInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[,]
                {
                    {0.5,0.5,1 }
                },
                1, 1 ,
            };


        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class OneStepTransitionProbabilityNegativeProbabilitiesInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[,]
                {
                    {-0.5,0.5,1 }
                },
                0, 1,
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PathProbabilitiesArrayInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[,]
                {
                    {0.2,0.25,0.25,0.25,0.05},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.09,0.3,0.3,0.3,0.01},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.2,0.1,0.3,0.15,0.25 },
                },
                new [] {0,1,2,4,3},
                0.0001125
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class PathProbabilitiesListInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[,]
                {
                    {0.2,0.25,0.25,0.25,0.05},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.09,0.3,0.3,0.3,0.01},
                    {0.2,0.1,0.3,0.15,0.25 },
                    {0.2,0.1,0.3,0.15,0.25 },
                },
                new List<int>{0,1,2,4,3},
                0.0015
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
