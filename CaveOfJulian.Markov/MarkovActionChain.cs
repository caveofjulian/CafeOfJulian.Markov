using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace CaveOfJulian.Markov
{
    /// <summary>
    /// This MarkovActionChain wraps a multidimensional array of Func<Tchain,TChain> to invoke the actions that have to be taken.
    /// </summary>
    /// <typeparam name="TChain"></typeparam>
    public class MarkovActionChain<TChain> : MarkovChain
    {
        private double[,] v;
        private Func<int, int>[,] func;

        public Func<TChain, TChain>[,] Actions { get; set; }
        
        public MarkovActionChain(Matrix<double> oneStepTransitionProbabilities, Func<TChain, TChain>[,] actions, IStochastic numberGenerator = null)
            : base(oneStepTransitionProbabilities, numberGenerator)
        {
            Actions = actions;
        }

        public MarkovActionChain(double[,] oneStepTransitionProbabilities, Func<TChain, TChain>[,] actions, IStochastic numberGenerator = null)
            : base(oneStepTransitionProbabilities, numberGenerator)
        {
            Actions = actions;
        }

        public void Run(int startState = 0)
        {
            TChain response = default;

            while (TryGetNextState(startState, out var nextState))
            {
                response = Actions[startState, nextState].Invoke(response);
                startState = nextState;
            }
        }
    }

    public class MarkovActionChain : MarkovChain
    {
        public Action[,] Actions { get; set; }

        public MarkovActionChain(Matrix<double> oneStepTransitionProbabilities, Action[,] actions, IStochastic numberGenerator = null)
            : base(oneStepTransitionProbabilities, numberGenerator)
        {
            Actions = actions;
        }

        public MarkovActionChain(double[,] oneStepTransitionProbabilities, Action[,] actions, IStochastic numberGenerator = null)
            : base(oneStepTransitionProbabilities, numberGenerator)
        {
            Actions = actions;
        }

        public void Run(int startState = 0)
        {
            while (TryGetNextState(startState, out var nextState))
            {
                Actions[startState, nextState].Invoke();
                startState = nextState;
            }
        }
    }
}
