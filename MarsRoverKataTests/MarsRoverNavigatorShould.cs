using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverNavigatorShould
    {
        [Test]
        public void ReturnEastWhenInputIsLeftAndStateIsNorth()
        {
            string startingDirection = "N";
            string inputControlSymbol = "L";

            string expected = "E";

            string actual = MarsRoverNavigator.Navigate(startingDirection, inputControlSymbol);

            Assert.AreEqual(expected, actual);
        }
    }
}
