using FluentAssertions;
using MarsRoverKata;
using MarsRoverKata.Navigation;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MovingControlShould
    {
        [TestCase('M', "N", 0, 0, 0, 1)]
        [TestCase('L', "N", 0, 0, 0, 0)]
        [TestCase('R', "N", 0, 0, 0, 0)]
        [TestCase('M', "S", 1, 1, 1, 0)]
        [TestCase('M', "E", 1, 1, 2, 1)]
        [TestCase('M', "W", 1, 1, 0, 1)]
        public void ReturnUpdatedCoordinates_WhenCorrectCommand(char command, string direction, int startingX,
            int startingY, int expectedX, int expectedY)
        {
            var expectedResult = new Coordinates
            {
                X = expectedX,
                Y = expectedY
            };

            var startingCoordinates = new Coordinates
            {
                X = startingX,
                Y = startingY
            };

            var movingControl = new MovingControl();
            var actualResult = movingControl.Move(command, direction, startingCoordinates);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
