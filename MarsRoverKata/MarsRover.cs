using MarsRoverKata.Navigation;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public MarsRover(string input)
        {
            navigationParameters = InputParser.GetNaviagtionParametersFromInput(input);
        }

        public string PositionAsAString { get; private set; }

        private readonly NavigationParameters navigationParameters;
        private MarsRoverNavigator marsRoverNavigator;

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(navigationParameters);

            var newPosition = marsRoverNavigator.Navigate();

            PositionAsAString = $"{newPosition.CurrentCoordinates.X} {newPosition.CurrentCoordinates.Y} {newPosition.CurrentDirection}";
        }
    }
}