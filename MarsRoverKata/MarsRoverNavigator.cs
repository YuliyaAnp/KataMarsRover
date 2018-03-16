using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class MarsRoverNavigator
    {
        private static LinkedList<string> directions = new LinkedList<string>(new [] { "N", "W", "S", "E" });

        readonly Dictionary<string,Func<string>> spinMethods = new Dictionary<string, Func<string>>
        {
            {"L", TurnLeft},
            {"R", TurnRight}
        };
        // public string CurrentDirection => currentDirection;
        static string currentDirection;

        public MarsRoverNavigator(string startingDirection)
        {
            currentDirection = startingDirection;
        }  

        public string Navigate(string inputControlSymbol)
        {
            currentDirection = spinMethods[inputControlSymbol]();
            return currentDirection;
        }

        private static string TurnRight()
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft()
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }
    }
}