using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using CaveOfJulian.Markov;

namespace CafeOfJulian.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DynamicInvokeVSInvoke>();
            Console.ReadKey();
            
        }
    }
}