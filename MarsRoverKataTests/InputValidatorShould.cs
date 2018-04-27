﻿using System;
using FluentAssertions;
using MarsRoverKata;
using MarsRoverKata.Exceptions;
using MarsRoverKata.Navigation;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class InputValidatorShould
    {
        [TestCase("5 5\n0 0 N\nM", 5, 5, 0, 0, "N", "M")]
        [TestCase("10 10\n5 9 E\nLMLMLM", 10, 10, 5, 9, "E", "LMLMLM")]
        public void GetNavigationParametersSuccessfully_WhenCorrectInput(string input, int expectedXPlateauDimension, int expectedYPlateauDimension,
                            int expectedXStartPosition, int expectedYStartPosition, string expectedDirection, string expectedCommand)
        {
            var expectedPlateausDimensions = new Coordinates { X = expectedXPlateauDimension, Y = expectedYPlateauDimension };
            var expectedStartingPosition = new Coordinates { X = expectedXStartPosition, Y = expectedYStartPosition };

            var expectedNavigationParameters = new NavigationParameters(expectedDirection, expectedPlateausDimensions, 
                                                        expectedStartingPosition, expectedCommand);

            var actualResult = InputValidator.GetNaviagtionParametersFromInput(input);

            actualResult.Should().BeEquivalentTo(expectedNavigationParameters);
        }

        [TestCase("10 10 5\n1 9 E\nLMLMLM")]
        [TestCase("10\n5 9 E\nLMLMLM")]
        [TestCase("10 A\n5 9 E\nLMLMLM")]
        public void ReturnException_WhenWrongPlateauDimensionsInput(string input)
        {
            Action actual = () => InputValidator.GetNaviagtionParametersFromInput(input);

            actual.Should().Throw<IncorrectPlateauDimensionsException>();
        }

        [TestCase("1 1\n1 1\nLMLMLM")]
        [TestCase("1 1\n1 N\nLMLMLM")]
        [TestCase("1 1\n1\nLMLMLM")]
        [TestCase("5 5\n5 A N\nLMLMLM")]
        [TestCase("5 5\n5 1 A\nLMLMLM")]
        [TestCase("1 1\n5 1 N\nLMLMLM")]
        public void ReturnException_WhenWrongStartPositionInput(string input)
        {
            Action actual = () => InputValidator.GetNaviagtionParametersFromInput(input);

            actual.Should().Throw<IncorrectStartPositionException>();
        }

        [TestCase("10 10; 5 9; LMLMLM")]
        [TestCase("10 10\nLMLMLM")]
        public void ReturnException_WhenWrongInputFormat(string input)
        {
            Action actual = () => InputValidator.GetNaviagtionParametersFromInput(input);

            actual.Should().Throw<IncorrectInputFormatException>();
        }
    }
}
