using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverNavigatorShould
    {
        [TestCase("N", "L", "W")]
        [TestCase("N", "R", "E")]
        [TestCase("W", "L", "S")]
        [TestCase("W", "R", "N")]
        [TestCase("S", "L", "E")]
        [TestCase("S", "R", "W")]
        [TestCase("E", "L", "N")]
        [TestCase("E", "R", "S")]
        public void ReturnEastWhenInputIsLeftAndStateIsNorth(string startingDirection, string inputControlSymbol, string expectedDirection)
        {
            var mrn = new MarsRoverNavigator(startingDirection);
            string actualDirection = mrn.Navigate(inputControlSymbol);

            Assert.AreEqual(expectedDirection, actualDirection);
        }
    }
}
