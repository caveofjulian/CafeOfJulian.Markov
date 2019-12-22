using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace CaveOfJulian.Markov
{
    public class MarkovActionChain : MarkovChain
    {
        public Action[,] Actions { get; set; }

        public MarkovActionChain(double[,] oneStepTransitionProbabilities, Action[,] actions) : base(oneStepTransitionProbabilities)
        {
            Actions = actions;
        }

        public MarkovActionChain(Matrix<double> oneStepTransitionProbabilities, Action[,] actions) : base(oneStepTransitionProbabilities)
        {
            Actions = actions;
        }

        public void Run(int startState = 0)
        {
            while (true)
            {
                var hasNextState = TryGetNextState(startState, out var nextState);
                if (!hasNextState) return;
                Actions[startState,nextState]?.Invoke();
                startState = nextState;
            }
        }
    }
}
