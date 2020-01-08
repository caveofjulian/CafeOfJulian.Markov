using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaveOfJulian.Tests.Input.cs
{
    public class Packet
    {
        public int LastValue { get; set; }
        public IDictionary<int,int> Values { get; set; }

        public Packet()
        {
            Values = new Dictionary<int, int> {{1, 0}, {2, 0}};
        }
    }

    internal class RunGenericMarkovActionChainInput : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new[,]
                {
                    {0d, 1d},
                    {0d, 0d}
                },
                new Func<Packet,Packet>[,]
                {
                    {AddOne, AddTwo},
                    {AddOne, AddTwo}
                },
                0.6,
                1
            };
            yield return new object[]
            {
                new [,]
                {
                    {1d, 0d},
                    {0d, 0d}
                },
                new Func<Packet,Packet>[,]
                {
                    {AddOne, AddTwo},
                    {AddOne, AddTwo}
                },
                0.6,
                0
            };
        }

        static Packet AddOne(Packet packet)
        {
            packet.Values[1] += 1;
            return packet;
        }

        static Packet AddTwo(Packet packet)
        {
            packet.Values[2] += 1;
            return packet;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class RunMarkovActionChainInput : IEnumerable<object[]>
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
