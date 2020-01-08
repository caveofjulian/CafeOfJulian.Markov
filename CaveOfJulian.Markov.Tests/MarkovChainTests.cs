using System;
using System.Collections.Generic;
using System.Threading;
using CaveOfJulian.Markov;
using CaveOfJulian.Markov.Exceptions;
using CaveOfJulian.Tests.Input.cs;
using Moq;
using Xunit;

namespace CaveOfJulian.Tests
{
    public class MarkovChainTests
    {

        [ClassData(typeof(AbsorbingStatesInput))]
        [Theory]
        public void Is_Markov_Chain_Absorbing_Should_Succeed(double[,] probabilities, bool expected)
        {
            var chain = new MarkovChain(probabilities);
            var actual = chain.IsAbsorbingState(0);
            Assert.Equal(expected, actual);
        }

        [ClassData(typeof(NormalizeNegativeInput))]
        [Theory]
        public void Normalize_Chain_Negative_Values_Should_Throw_NegativeProbabilityException(double[,] probabilities)
        {
            var chain = new MarkovChain(probabilities);
            Assert.Throws<NegativeProbabilityException>(chain.Normalize);
        }

        [ClassData(typeof(NormalizeSuccessInput))]
        [Theory]
        public void Normalize_Chain_Valid_Values_Should_Normalize(double[,] probabilities, double[,] expected)
        {
            var chain = new MarkovChain(probabilities);
            chain.Normalize();
            var actual = chain.OneStepTransitionProbabilities.ToArray();
            Assert.Equal(expected, actual);
        }

        [ClassData(typeof(OneStepTransitionProbabilityInput))]
        [Theory]
        public void OneStepTransitionProbability_valid_start_end_succeeds(double[,] probabilities, int start, int end,
            double expected)
        {
            var chain = new MarkovChain(probabilities);
            var actual = chain.CalculateProbability(start, end);
            Assert.Equal(expected,actual);
        }

        [ClassData(typeof(OneStepTransitionProbabilityInvalidStartEndInput))]
        [Theory]
        public void OneStepTransitionProbability_invalid_start_end_should_throw(double[,] probabilities, int start, int end)
        {
            var chain = new MarkovChain(probabilities);
            Assert.Throws<ArgumentOutOfRangeException>(() => chain.CalculateProbability(start, end));
        }

        [ClassData(typeof(OneStepTransitionProbabilityNegativeProbabilitiesInput))]
        [Theory]
        public void OneStepTransitionProbability_negative_probabilities_should_throw(double[,] probabilities, int start, int end)
        {
            var chain = new MarkovChain(probabilities);
            Assert.Throws<NegativeProbabilityException>(() => chain.CalculateProbability(start, end));
        }

        [ClassData(typeof(PathProbabilitiesArrayInput))]
        [Theory]
        public void Path_Array_Succeeds(double[,] probabilities, int[] path, double expected)
        {
            var chain = new MarkovChain(probabilities);
            var actual = chain.CalculateProbability(path);
            Assert.Equal(expected,actual);
        }

        [ClassData(typeof(PathProbabilitiesListInput))]
        [Theory]
        public void Path_List_Succeeds(double[,] probabilities, List<int> path, double expected)
        {
            var chain = new MarkovChain(probabilities);
            var actual = chain.CalculateProbability(path);
            Assert.Equal(expected,actual);
        }

        /*
        [Theory]
        public void GetNextState_Should_Throw(double[,] probabilities, int state, int stochasticReturn)
        {
            var mock = new Mock<IStochastic>();
            mock.Setup(m => m.NextDouble()).Returns(stochasticReturn);

            var chain = new MarkovChain(probabilities, mock.Object);
            
            Assert.Throws()
            chain.GetNextState(state);
            throw new NotImplementedException();
        }

        //[Theory]
        public void TryGetNextState(double[,] probabilities)
        {
            var chain = new MarkovChain(probabilities);
            var succeeded = chain.TryGetNextState(0,out var state);
            throw  new NotImplementedException();
        }*/

    }
}
