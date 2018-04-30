using MarsRoverKata.Navigation;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public MarsRover(string input)
        {
            navigationParameters = InputParser.GetNavigationParametersFromInput(input);
            command = InputParser.GetCommandFromInput(input);
        }

        public string PositionAsAString { get; private set; }

        private readonly NavigationParameters navigationParameters;
        private MarsRoverNavigator marsRoverNavigator;
        private string command;

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(navigationParameters);

            var newPosition = marsRoverNavigator.Navigate(command);

            PositionAsAString = $"{newPosition.CurrentCoordinates.X} {newPosition.CurrentCoordinates.Y} {newPosition.CurrentDirection}";
        }
    }
}