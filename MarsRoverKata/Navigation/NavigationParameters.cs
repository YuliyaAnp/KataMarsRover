using System;

namespace MarsRoverKata
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; }
        public Coordinates PlateauDimenstions { get; }
        public Coordinates CurrentCoordinates { get; private set; }

        public NavigationParameters(string currentDirection, Coordinates plateauDimenstions, Coordinates currentCoordinates, string command)
        {
            CurrentDirection = currentDirection;
            PlateauDimenstions = plateauDimenstions;
            CurrentCoordinates = currentCoordinates;
            Command = command;
        }

        public void UpdateCurrentDirection(string newDirection)
        {
            CurrentDirection = newDirection;
        }

		internal void UpdateCurrentCoordinates(Coordinates newCoordinates)
		{
            CurrentCoordinates = newCoordinates;
		}
	}
}
