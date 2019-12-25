using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using CaveOfJulian.Markov;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace CafeOfJulian.Benchmarks
{
    public class DynamicInvokeMarkovChain<T> : MarkovChain where T:Delegate
    {
        public T[,] Actions { get; set; }

        public DynamicInvokeMarkovChain(double[,] oneStepTransitionProbabilities, T[,] actions, IStochastic numberGenerator = null)
            : base(oneStepTransitionProbabilities, numberGenerator)
        {
            Actions = actions;
        }

        public void Run(int startState = 0)
        {
            T response = default;

            while (TryGetNextState(startState, out var nextState))
            {
                response = (T) Actions[startState, nextState].DynamicInvoke(response);
                startState = nextState;
            }
        }
    }
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    [RPlotExporter]
    public class DynamicInvokeVSInvoke
    {
        DynamicInvokeMarkovChain<Func<int,int>> DynamicInvokeChain = new DynamicInvokeMarkovChain<Func<int,int>>(
            new double[,]{{0,1},{0,0}}, new Func<int,int>[,]{{Foo}} );

        MarkovActionChain<int> InvokeChain = new MarkovActionChain<int>(
            new double[,] { { 0, 1 }, { 0, 0 } }, new Func<int,int>[,] { { Foo } });
        
        [Benchmark]
        public void Invoke()
        {
            InvokeChain.Run();   
        }

        [Benchmark]
        public void DynamicInvoke()
        {
            DynamicInvokeChain.Run();
        }

        public static void Foo()
        {
            Console.WriteLine("test");
        }

        public static int Foo(int x)
        {
            Console.WriteLine("test");
            return x;
        }
    }
}
