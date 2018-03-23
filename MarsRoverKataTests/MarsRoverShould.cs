using System;
using FluentAssertions;
using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverShould
    {
        [TestCase("5 5\n0 0 N\nM", 5, 5, 0, 0, "N", "M")]
        [TestCase("1 10\n5 9 E\nLMLMLM", 1, 10, 5, 9, "E", "LMLMLM")]
        public void ParseAnInputCorrectly(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
                            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var marsRover = new MarsRover(input);
            marsRover.Initialize();

            var expectedPlateausDimensions = new Coordinates() { X = expectedXPlateauDimension, Y = expectedYPlateauDimension };
            var expectedStartingPosition = new Coordinates() { X = expectedXStartPosition, Y = expectedYStartPosition };

            marsRover.PlateauDimenstions.Should().BeEquivalentTo(expectedPlateausDimensions);
            marsRover.CurrentCoordinates.Should().BeEquivalentTo(expectedStartingPosition);
            marsRover.CurrentDirection.Should().BeEquivalentTo(expectedDirection);
            marsRover.Command.Should().BeEquivalentTo(expectedCommand);
        }

        [TestCase("1 10 5\n5 9 E\nLMLMLM", 1, 10, 5, 9, "E", "LMLMLM")]
        public void ReturnExceptionWhenWrongPlateauDimensionsInput(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<ArgumentException>()
                .WithMessage("Plateau dimensions should contain two parameters: x and y");
        }

        [TestCase("1 10\n5 9\nLMLMLM", 1, 10, 5, 9, "E", "LMLMLM")]
        public void ReturnExceptionWhenWrongStartPositionInput(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<ArgumentException>()
                .WithMessage("Current position and direction should contain three parameters: x, y and direction");
        }

        [TestCase("1 10; 5 9; LMLMLM", 1, 10, 5, 9, "E", "LMLMLM")]
        public void ReturnExceptionWhenWrongInputFormat(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<Exception>()
                .WithMessage("Error occured while splitting the input: format is incorrect");
        }
    }
}
