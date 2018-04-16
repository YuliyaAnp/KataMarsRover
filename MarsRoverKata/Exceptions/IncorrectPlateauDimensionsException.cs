using System;

namespace MarsRoverKata.Exceptions
{
    public class IncorrectPlateauDimensionsException : Exception
    {
        private const string incorrectPlateauDimensionsErrorMessage = "Plateau dimensions should contain two int parameters: x and y";

        public IncorrectPlateauDimensionsException() : base(incorrectPlateauDimensionsErrorMessage)
        {
        }
    }
}
