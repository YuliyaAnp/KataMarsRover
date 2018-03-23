using System;
using MarsRoverKata;
using NUnit.Framework;
using FluentAssertions;

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
            var marsRover = new MarsRover(startingDirection);
            var marsRoverNavigator = new MarsRoverNavigator(marsRover);

            marsRoverNavigator.ChangeDirection(inputControlSymbol);

            var actualDiretion = marsRover.CurrentDirection;

            Assert.AreEqual(expectedDirection, actualDiretion);
        }
    }
}
