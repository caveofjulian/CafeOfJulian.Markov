using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Tests.Input.cs
{
    public class RunGenericMarkovActionChainInput : IEnumerable<object[]>
    {
        internal static int Action1 = 0, Action2 = 0;

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new[,]
                {
                    {0.5, 0.5},
                    {0, 0}
                },
                new Action[,]
                {
                    {() => AddOne(ref Action1), () => AddOne(ref Action2)},
                    {() => AddOne(ref Action1), () => AddOne(ref Action2)}
                },
                0.6,
                1
            };
            yield return new object[]
            {
                new double[,]
                {
                    {0, 1},
                    {0, 0}
                },
                new Action[,]
                {
                    {() => AddOne(ref Action1), () => AddOne(ref Action2)},
                    {() => AddOne(ref Action1), () => AddOne(ref Action2)}
                },
                0.6,
                1
            };
        }

        static void AddOne(ref int i)
        {
            i++;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
