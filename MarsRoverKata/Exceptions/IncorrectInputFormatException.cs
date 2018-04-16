using System;

namespace MarsRoverKata.Exceptions
{
    public class IncorrectInputFormatException : Exception
    {
        private const string incorrectInputFormatErrorMessage = "Error occured while splitting the input: format is incorrect";

        public IncorrectInputFormatException() : base(incorrectInputFormatErrorMessage)
        {
        }
    }
}