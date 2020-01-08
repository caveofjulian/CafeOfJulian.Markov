using System;
using System.Collections.Generic;
using System.Text;
using CaveOfJulian.Markov;
using CaveOfJulian.Tests.Input.cs;
using MathNet.Numerics.LinearAlgebra;
using Moq;
using Xunit;

namespace CaveOfJulian.Tests
{
    public class MarkovActionChainTests
    {
        [ClassData(typeof(RunMarkovActionChainInput))]
        [Theory]
        public void Run_Chain_Succeeds(double[,] probabilities, Action[,] actions, int mockedProbability, int expected)
        {
            var mock = new Mock<IStochastic>();
            mock.Setup(m => m.NextDouble()).Returns(mockedProbability);

            var chain = new MarkovActionChain(probabilities, actions,mock.Object);
            chain.Run();

            Assert.Equal(expected, RunMarkovActionChainInput.Action2);
        }

        [ClassData(typeof(RunGenericMarkovActionChainInput))]
        [Theory]
        public void Run_Generic_Chain_Succeeds(double[,] probabilities, Func<Packet, Packet>[,] actions, int mockedProbability, int expected)
        {
            var mock = new Mock<IStochastic>();
            mock.Setup(m => m.NextDouble()).Returns(mockedProbability);

            var chain = new MarkovActionChain<Packet>(probabilities, actions,null, mock.Object);
            chain.Run();

            var actual = chain.LastValue.Values[2];
            Assert.Equal(expected, actual);
        }


    }
}
