using System;
using System.Collections.Generic;
using System.Threading;
using BenchmarkDotNet.Running;
using CaveOfJulian.Markov;

namespace CafeOfJulian.Benchmarks
{
    struct VertexZ
    {
       // private static VertexZ trash = new VertexZ();
   //     public static VertexZ TrashVertex => trash;

        public readonly int Id;
        public int Index { get; set; }
        public int Lowlink { get; set; }

        public HashSet<VertexZ> Dependencies { get; set; }

        public VertexZ(int x = 0)
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
            Dependencies = new HashSet<VertexZ>();
        }
    }

    unsafe class VertexA 
    {
        private static VertexA trash = new VertexA();

        public static VertexA TrashVertex => trash;

        public int Id { get; set; }
        public int Index { get; set; }
        public int Lowlink { get; set; }

        public HashSet<VertexA> Dependencies { get; set; }

        public VertexA()
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
            Dependencies = new HashSet<VertexA>
            {
                TrashVertex,
                TrashVertex,
                TrashVertex,
                TrashVertex
            };
        }
    }

    unsafe class VertexB
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public int Lowlink { get; set; }

        public VertexB()
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
        }
    }

    unsafe struct VertexC
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public int Lowlink { get; set; }

        public VertexC(int i)
        {
            Id = -1;
            Index = -1;
            Lowlink = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ListBenchmark>();
            Console.ReadKey();
        }

        public static void Talk()
        {
            Console.WriteLine("Hi, how are you?");
        }

        public static void Bark()
        {
            Console.WriteLine("WOOOF!");
        }

        public static void Laugh()
        {
            Console.WriteLine("HAHAHAHA");
        }

    }
}
