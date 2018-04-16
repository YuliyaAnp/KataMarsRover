using MarsRoverKata;
using NUnit.Framework;
using FluentAssertions;
using MarsRoverKata.Exceptions;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverNavigatorShould
    {
        [TestCase("5 5\n0 0 N\nL", "0 0 W")]
        [TestCase("5 5\n0 0 N\nR", "0 0 E")]
        [TestCase("5 5\n0 0 W\nL", "0 0 S")]
        [TestCase("5 5\n0 0 W\nR", "0 0 N")]
        [TestCase("5 5\n0 0 S\nL", "0 0 E")]
        [TestCase("5 5\n0 0 S\nR", "0 0 W")]
        [TestCase("5 5\n0 0 E\nL", "0 0 N")]
        [TestCase("5 5\n0 0 E\nR", "0 0 S")]
        [TestCase("5 5\n1 1 N\nM", "1 2 N")]
        [TestCase("5 5\n1 1 W\nM", "0 1 W")]
        [TestCase("5 5\n1 1 S\nM", "1 0 S")]
        [TestCase("5 5\n1 1 E\nM", "2 1 E")]
        public void UpdateDirectionWhenPassSpinDirections(string input, string expectedDirection)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            marsRover.Navigate();

            var actualResult = marsRover.FinalPosition;

            actualResult.Should().BeEquivalentTo(expectedDirection);
        }

        [TestCase("5 5\n0 0 N\nM", "0 1 N")]
        [TestCase("5 5\n1 1 N\nMLMR", "0 2 N")]
        [TestCase("5 5\n1 1 W\nMLMLMLM", "1 1 N")]
        [TestCase("5 5\n0 0 N\nMMMMM", "0 5 N")]
        [TestCase("5 5\n0 0 E\nMMMMM", "5 0 E")]
        [TestCase("5 5\n0 0 N\nRMLMRMLMRMLMRMLM", "4 4 N")]
        public void UpdatePositionWhenPassCorrectInput(string input, string expectedPosition)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            marsRover.Navigate();

            var actualResult = marsRover.FinalPosition;

            actualResult.Should().BeEquivalentTo(expectedPosition);
        }

        [TestCase("1 1\n0 0 N\nMM")]
        [TestCase("1 1\n0 0 E\nMM")]
        public void ReturnExceptionWhenCommandSendsRoverOutOfPlateau(string input)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();

            marsRover.Invoking(y => y.Navigate())
                     .Should().Throw<InvalidCommandException>()
                     .WithMessage("Command is invalid: Rover is sent outside the Plateau");
            }
    }
}
