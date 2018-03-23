using System;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace MarsRoverKata
{
    public class MarsRoverNavigator
    {
        private static LinkedList<string> directions = new LinkedList<string>(new [] { "N", "W", "S", "E" });

        readonly Dictionary<char,Func<string, string>> spinMethods = new Dictionary<char, Func<string, string>>
        {
            {'L', TurnLeft},
            {'R', TurnRight},
            {'M', Stay }
        };

        public string CurrentDirection { get; private set; }
        public char[] Command { get; private set; }
        public Coordinates PlateauDimenstions { get; private set; }
        public Coordinates CurrentCoordinates { get; private set; }

        private string input;

        public MarsRoverNavigator(char startingDirection)
        {
            CurrentDirection = startingDirection.ToString();
        }

        public MarsRoverNavigator(string input)
        {
            this.input = input;
        }

        public void Initialize()
        {
            string[] inputByLines = SplitInputByLines(input);
            SetPlateauDimensions(inputByLines);
            SetCurrentPositionAndDirection(inputByLines);
            Command = inputByLines[2].ToCharArray();
        }

        private void SetCurrentPositionAndDirection(string[] inputByLines)
        {
            var stringCurrentPositionAndDirection = inputByLines[1].Split(' ');
            
            if (stringCurrentPositionAndDirection.Length != 3)
            {
                Console.WriteLine("Current position and direction should contain three parameters: x, y and direction");
                throw new ArgumentException("Current position and direction should contain three parameters: x, y and direction");
            }

            CurrentCoordinates = new Coordinates
            {
                X = Int32.Parse(stringCurrentPositionAndDirection[0]),
                Y = Int32.Parse(stringCurrentPositionAndDirection[1])
            };

            CurrentDirection = stringCurrentPositionAndDirection[2];
        }

        private void SetPlateauDimensions(string[] inputLines)
        {
            var stringPlateauDimenstions = inputLines[0].Split(' ');
            if (stringPlateauDimenstions.Length != 2)
            {
                Console.WriteLine("Plateau dimensions should contain two parameters: x and y");
                throw new ArgumentException("Plateau dimensions should contain two parameters: x and y");
            }

            PlateauDimenstions = new Coordinates
            {
                X = Int32.Parse(stringPlateauDimenstions[0]),
                Y = Int32.Parse(stringPlateauDimenstions[1])
            };
        }

        private static string[] SplitInputByLines(string input)
        {
            if (!input.Contains("\n"))
            {
                throw new Exception("Error occured while splitting the input: format is incorrect"); 
            }
            return input.Split('\n');
        }

        public string DoAStep(char inputControlSymbol)
        {
            CurrentDirection = spinMethods[inputControlSymbol](CurrentDirection);
            return CurrentDirection;
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