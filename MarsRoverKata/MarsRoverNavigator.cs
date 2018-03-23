using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class MarsRoverNavigator
    {
        public MarsRover MarsRover { get; }

        public MarsRoverNavigator(MarsRover marsRover)
        {
            MarsRover = marsRover;
        }

        private static LinkedList<string> directions = new LinkedList<string>(new[] { "N", "W", "S", "E" });

        readonly Dictionary<char, Func<string, string>> spinMethods = new Dictionary<char, Func<string, string>>
        {
            {'L', TurnLeft},
            {'R', TurnRight},
            {'M', Stay }
        };


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

        public void ChangeDirection(char directionChangeCommand)
        {
            MarsRover.SetCurrentDirection(spinMethods[directionChangeCommand](MarsRover.CurrentDirection));
        }
    }
}
