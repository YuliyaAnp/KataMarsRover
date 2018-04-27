using MarsRoverKata.Navigation;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private MarsRoverNavigator marsRoverNavigator;

        public MarsRover(string input)
        {
            navigationParameters = InputValidator.GetNaviagtionParametersFromInput(input);
           // command = InputValidator.GetCommandFromInput(input);
        }

        private NavigationParameters navigationParameters { get; }
        public string PositionAsAString { get; private set; }

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(navigationParameters);

            var newPosition = marsRoverNavigator.Navigate();

            PositionAsAString = $"{newPosition.CurrentCoordinates.X} {newPosition.CurrentCoordinates.Y} {newPosition.CurrentDirection}";
        }
    }
}