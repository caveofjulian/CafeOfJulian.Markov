using System;
using System.Collections.Generic;
using System.Threading;
using BenchmarkDotNet.Running;
using CaveOfJulian.Markov;

namespace CafeOfJulian.Benchmarks
{
   class Program
    {
        static void Main(string[] args)
        {
            double[,] probabilities =
            {
                {0,0.5,0.5 },
                {0.5,0,0.5 },
                {0.5,0.5,0 }
            };

            Func<int, int>[] funcs =
            {
                Func, 
            };

            var chain = new MarkovChain<Func<int,int>>(probabilities,funcs);

            BenchmarkRunner.Run<ListBenchmark>();
            Console.ReadKey();
        }

        private static int Func(int arg)
        {
            throw new NotImplementedException();
        }

        static void DoSomething(int x)
        {

        }
    }
}
