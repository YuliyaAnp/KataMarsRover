using System;

namespace MarsRoverKata.Exceptions
{
    public class IncorrectStartPositionException : Exception
    {
        private const string incorrectStartPositionErrorMessage = "Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)";

        public IncorrectStartPositionException() : base(incorrectStartPositionErrorMessage)
        {
        }
    }
}