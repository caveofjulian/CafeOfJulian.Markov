using System;
using CaveOfJulian.Markov;
using CaveOfJulian.Markov.Exceptions;
using CaveOfJulian.Tests.Input.cs;
using Xunit;

namespace CaveOfJulian.Tests
{
    public class MarkovChainTests
    {
        [Fact]
        public void Get_Random_()
        {

        }

        [ClassData(typeof(NormalizeNegativeInput))]
        [Theory]
        public void Normalize_Chain_Negative_Values_Should_Throw_NegativeProbabilityException(double[,] probabilities, double[,] expected)
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
            Assert.Equal(expected, chain.OneStepTransitionProbabilities.ToArray());
        }
    }
}
