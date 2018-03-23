using MarsRoverKata;
using NUnit.Framework;
using FluentAssertions;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverNavigatorShould
    {
        [TestCase("5 5\n0 0 N\nM", 'L', "W")]
        [TestCase("5 5\n0 0 N\nM", 'R', "E")]
        [TestCase("5 5\n0 0 W\nM", 'L', "S")]
        [TestCase("5 5\n0 0 W\nM", 'R', "N")]
        [TestCase("5 5\n0 0 S\nM", 'L', "E")]
        [TestCase("5 5\n0 0 S\nM", 'R', "W")]
        [TestCase("5 5\n0 0 E\nM", 'L', "N")]
        [TestCase("5 5\n0 0 E\nM", 'R', "S")]
        [TestCase("5 5\n0 0 N\nM", 'M', "N")]
        [TestCase("5 5\n0 0 W\nM", 'M', "W")]
        [TestCase("5 5\n0 0 S\nM", 'M', "S")]
        [TestCase("5 5\n0 0 E\nM", 'M', "E")]
        public void UpdateDirectionWhenPassInitialAndSpinDirections(string input, char inputControlSymbol, string expectedDirection)
        {
            //var marsRover = new MarsRover(input);
            //marsRover.Initialize();
            //var marsRoverNavigator = new MarsRoverNavigator(marsRover);

            //marsRoverNavigator.ChangeDirection(inputControlSymbol);

            //var actualDiretion = marsRover.CurrentDirection;

            //actualDiretion.Should().BeEquivalentTo(expectedDirection);
        }

        [TestCase("5 5\n0 0 N\nM", "0 1 N")]
        public void UpdatePositionWhenPassCorrectInput(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            //var marsRover = new MarsRover(input);
            //marsRover.Initialize();

            //marsRover.Navigate();
            //var marsRoverNavigator = new MarsRoverNavigator(marsRover);

           // marsRoverNavigator.Navigate()
        }
    }
}
