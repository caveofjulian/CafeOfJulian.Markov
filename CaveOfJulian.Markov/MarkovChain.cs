using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CaveOfJulian.Markov.Exceptions;
using CaveOfJulian.Markov.Extensions;
using MathNet.Numerics.LinearAlgebra;

namespace CaveOfJulian.Markov
{
    public class MarkovChain
    {
        /// <summary>
        /// One step transition probabilities corresponding to the Markov Chain.
        /// </summary>
        public Matrix<double> OneStepTransitionProbabilities { get; set; }

        private readonly IStochastic _numberGenerator;

        public MarkovChain(Matrix<double> oneStepTransitionProbabilities, IStochastic numberGenerator = null)
        {
            OneStepTransitionProbabilities = oneStepTransitionProbabilities;
            _numberGenerator = numberGenerator ?? new Rnd();
        }

        public MarkovChain(double[,] oneStepTransitionProbabilities, IStochastic numberGenerator = null)
        {
            OneStepTransitionProbabilities = Matrix<double>.Build.DenseOfArray(oneStepTransitionProbabilities);
            _numberGenerator = numberGenerator ?? new Rnd();
        }

        /// <summary>
        /// Returns random end state, depending on the number of steps. The last chain is always returned, even if the chain ends prematurely.
        /// </summary>
        /// <param name="startState"></param>
        /// <returns></returns><param name="steps"></param>
        public int GetNextState(int startState, int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                startState = GetNextState(startState);
            }

            return startState;
        }

        /// <summary>
        /// Returns the next state randomly based on the one step transition probabilities.
        /// Throws when there is no feasible next state.
        /// </summary>
        /// <param name="startState">Starting state.</param>
        /// <returns>Next state. Returns -1 if there is no feasible next state.</returns>
        public int GetNextState(int startState)
        {
            const int stateNotFound = -1;
            var randomProbability = _numberGenerator.NextDouble();
            var sum = 0d;

            for (var i = 0; i < OneStepTransitionProbabilities.ColumnCount; i++)
            {
                var probability = OneStepTransitionProbabilities[startState, i];
                sum += probability;
                if (randomProbability < sum) return i;
            }

            return stateNotFound;
        }

        /// <summary>
        /// Returns the one step transition probability from the starting state to the next state.
        /// </summary>
        /// <param name="start">Starting state.</param>
        /// <param name="next">Next state.</param>
        /// <returns></returns>
        public double CalculateProbability(int start, int next) => OneStepTransitionProbabilities[start, next];
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="states">Sequence of states. The first index is the starting state.</param>
        /// <returns></returns>
        public double CalculateProbability(int[] states) => CalculatePathProbability(states);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="states">Sequence of states. The first index is the starting state.</param>
        /// <returns></returns>
        public double CalculateProbability(IList<int> states) => CalculatePathProbability(states);

        private double CalculatePathProbability(IEnumerable<int> steps)
        {
            if(steps is null) throw new ArgumentNullException(nameof(steps));
            
            double result = 1;

            if(!steps.Any()) throw new InvalidMarkovOperationException($"{nameof(steps)} cannot be empty!");
            
            var currentState = steps.First();

            foreach (var step in steps)
            {
                result *= OneStepTransitionProbabilities[currentState, step];
                if(result < 0) throw new NegativeProbabilityException();
                currentState = step;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="acceptedDifference"></param>
        /// <returns></returns>
        public bool IsAbsorbingState(int state, double acceptedDifference = 0.005)
        {
            return OneStepTransitionProbabilities[state, state].Equals(1, acceptedDifference);
        }

        public double AverageSteps(int startState = 0)
        {
            var determinant = OneStepTransitionProbabilities.Determinant();

            if(determinant is 0) 
                throw new InvalidMarkovOperationException("Determinant cannot be 0!");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Normalizes all row vectors to 1.0.
        /// </summary>
        public void Normalize()
        {
            if(OneStepTransitionProbabilities.ContainsNegativeValue()) 
                throw new NegativeProbabilityException("Matrix may not contain negative values!");

            OneStepTransitionProbabilities = OneStepTransitionProbabilities.NormalizeRows(1.0);
        }
    }
}


