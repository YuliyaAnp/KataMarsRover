using System;

namespace MarsRoverKata.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string invalidCommandErrorMessage = "Command is invalid: Rover is sent outside the Plateau";

        public InvalidCommandException() : base(invalidCommandErrorMessage)
        {
        }
    }
}
