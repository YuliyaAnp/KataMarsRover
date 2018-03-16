using System;
using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverNavigatorShould
    {
        [TestCase('N', 'L', "W")]
        [TestCase('N', 'R', "E")]
        [TestCase('W', 'L', "S")]
        [TestCase('W', 'R', "N")]
        [TestCase('S', 'L', "E")]
        [TestCase('S', 'R', "W")]
        [TestCase('E', 'L', "N")]
        [TestCase('E', 'R', "S")]
        [TestCase('N', 'M', "N")]
        [TestCase('W', 'M', "W")]
        [TestCase('S', 'M', "S")]
        [TestCase('E', 'M', "E")]
        public void ReturnCorrectFinalDirectionWhenPassInitialAndSpinDirections(char startingDirection, char inputControlSymbol, string expectedDirection)
        {
            var mrn = new MarsRoverNavigator(startingDirection);
            string actualDirection = mrn.DoAStep(inputControlSymbol);

            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [TestCase("5 5\n0 0 N\nM", "0 1 N")]
        public void ReturnCorrectFinalPositionWhenPassACommand(string command, string expectedPosition)
        {
            var mrn = new MarsRoverNavigator(command);
            string actualPosition = mrn.Navigate();

            Assert.AreEqual(expectedPosition, actualPosition);
        }
    }
}
