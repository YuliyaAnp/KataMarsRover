namespace MarsRoverKata.Navigation
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; private set; }
        public Coordinates PlateauDimensions { get; }
        public Coordinates CurrentCoordinates { get; private set; }

        public NavigationParameters(string currentDirection, Coordinates plateauDimensions, Coordinates currentCoordinates, string command)
        {
            CurrentDirection = currentDirection;
            PlateauDimensions = plateauDimensions;
            CurrentCoordinates = currentCoordinates;
            Command = command;
        }
	}
}
