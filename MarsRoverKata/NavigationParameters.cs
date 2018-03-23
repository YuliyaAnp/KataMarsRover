using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class NavigationParameters
    {
        public string CurrentDirection { get; private set; }
        public char[] Command { get; }
        public Coordinates PlateauDimenstions { get; }
        public Coordinates CurrentCoordinates { get;  }

        public NavigationParameters(string currentDirection, Coordinates plateauDimenstions, Coordinates currentCoordinates, char[] command)
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
    }
}
