using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class MarsRoverNavigator
    {
        private readonly NavigationParameters navigationParameters;
        private static readonly LinkedList<string> directions = new LinkedList<string>(new[] { "N", "W", "S", "E" });

        readonly Dictionary<char, Func<string, string>> spinMethods = new Dictionary<char, Func<string, string>>
        {
            {'L', TurnLeft},
            {'R', TurnRight},
            {'M', Stay }
        };

        public MarsRoverNavigator(NavigationParameters navigationParameters)
        {
            this.navigationParameters = navigationParameters;
        }
        
        public void ChangeDirection(char directionChangeCommand)
        {
            SetCurrentDirection(spinMethods[directionChangeCommand](navigationParameters.CurrentDirection));
        }

        public void SetCurrentDirection(string newDirection)
        {
            navigationParameters.UpdateCurrentDirection(newDirection);
        }

        public string Navigate()
        {
            return String.Empty;
        }

        private static string TurnRight(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }

        private static string Stay(string currentDirection)
        {
            return currentDirection;
        }
    }
}
