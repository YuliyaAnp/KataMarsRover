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
        [TestCase("10 10\n5 9 E\nLMLMLM", 10, 10, 5, 9, "E", "LMLMLM")]
        public void ParseAnInputCorrectly(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
                            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var expectedPlateausDimensions = new Coordinates() { X = expectedXPlateauDimension, Y = expectedYPlateauDimension };
            var expectedStartingPosition = new Coordinates() { X = expectedXStartPosition, Y = expectedYStartPosition };

            var expectedNavigationParameters = new NavigationParameters(expectedDirection, expectedPlateausDimensions, 
                                                        expectedStartingPosition, expectedCommand);

            var marsRover = new MarsRover(input);
            marsRover.Initialize();
            var actualResult = marsRover.NavigationParameters;

            actualResult.Should().BeEquivalentTo(expectedNavigationParameters);
        }

        [TestCase("10 10 5\n1 9 E\nLMLMLM")]
        [TestCase("10\n5 9 E\nLMLMLM")]
        [TestCase("10 A\n5 9 E\nLMLMLM")]
        public void ReturnExceptionWhenWrongPlateauDimensionsInput(string input)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<ArgumentException>()
                .WithMessage("Plateau dimensions should contain two int parameters: x and y");
        }

        [TestCase("1 1\n1 1\nLMLMLM")]
        [TestCase("1 1\n1 N\nLMLMLM")]
        [TestCase("1 1\n1\nLMLMLM")]
        [TestCase("5 5\n5 A N\nLMLMLM")]
        [TestCase("5 5\n5 1 A\nLMLMLM")]
        [TestCase("1 1\n5 1 N\nLMLMLM")]
        public void ReturnExceptionWhenWrongStartPositionInput(string input)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<ArgumentException>()
                     .WithMessage("Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)");
        }

        [TestCase("10 10; 5 9; LMLMLM")]
        [TestCase("10 10\nLMLMLM")]
        public void ReturnExceptionWhenWrongInputFormat(string input)
        {
            var marsRover = new MarsRover(input);

            marsRover.Invoking(y => y.Initialize())
                .Should().Throw<Exception>()
                .WithMessage("Error occured while splitting the input: format is incorrect");
        }
    }
}
