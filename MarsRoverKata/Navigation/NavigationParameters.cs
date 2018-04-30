namespace MarsRoverKata.Navigation
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; }
        public Coordinates PlateauDimensions { get; }
        public Coordinates CurrentCoordinates { get; }

        public NavigationParameters(string currentDirection, Coordinates plateauDimensions, Coordinates currentCoordinates)
        {
            CurrentDirection = currentDirection;
            PlateauDimensions = plateauDimensions;
            CurrentCoordinates = currentCoordinates;
        }
	}
}
