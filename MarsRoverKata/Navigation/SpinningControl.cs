using System;
using System.Collections.Generic;
using MarsRoverKata.Constants;

namespace MarsRoverKata.Navigation
{
    public class SpinningControl
    {
        private readonly Dictionary<char, Func<string, string>> spinningFunctions =
                                new Dictionary<char, Func<string, string>>
        {
            {Commands.Left, TurnLeft},
            {Commands.Right, TurnRight},
            {Commands.Move, Stay }
        };

        public string GetNextDirection(string currentDirection, char stepCommand)
        {
            return spinningFunctions[stepCommand](currentDirection);
        }

        private static string TurnRight(string currentDirection)
        {
            LinkedListNode<string> currentIndex = Directions.AllowedDirections.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft(string currentDirection)
        {
            LinkedListNode<string> currentIndex = Directions.AllowedDirections.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }

        private static string Stay(string currentDirection)
        {
            return currentDirection;
        }
    }
}
