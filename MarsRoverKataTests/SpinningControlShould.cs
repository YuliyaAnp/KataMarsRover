using FluentAssertions;
using MarsRoverKata.Navigation;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class SpinningControlShould
    {
        [TestCase("N", 'L', "W")]
        [TestCase("N", 'R', "E")]
        [TestCase("W", 'L', "S")]
        [TestCase("W", 'R', "N")]
        [TestCase("S", 'L', "E")]
        [TestCase("S", 'R', "W")]
        [TestCase("E", 'L', "N")]
        [TestCase("E", 'R', "S")]
        [TestCase("N", 'M', "N")]
        [TestCase("W", 'M', "W")]
        [TestCase("S", 'M', "S")]
        [TestCase("E", 'M', "E")]
        public void ReturnUpdatedCoordinates_WhenCorrectCommand(string startingDirection, char command, string expectedDirection)
        {
            var spinningControl = new SpinningControl();

            var actualResult = spinningControl.GetNextDirection(startingDirection, command);

            actualResult.Should().BeEquivalentTo(expectedDirection);
        }
    }
}
