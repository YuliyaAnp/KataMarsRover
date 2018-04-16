using System;
using System.Collections.Generic;

namespace MarsRoverKata.Navigation
{
    public class SpinningControl
    {
        static readonly LinkedList<string> directions =
                        new LinkedList<string>(new[] { "N", "W", "S", "E" });

        public readonly Dictionary<char, Func<string, string>> SpinningFunctions =
                                new Dictionary<char, Func<string, string>>
        {
            {'L', TurnLeft},
            {'R', TurnRight},
            {'M', Stay }
        };

        public string GetNextDirection(string currentDirection, char stepCommand)
        {
            return SpinningFunctions[stepCommand](currentDirection);
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
