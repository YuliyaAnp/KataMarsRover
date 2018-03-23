using System;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public string CurrentDirection { get; private set; }
        public char[] Command { get; private set; }
        public Coordinates PlateauDimenstions { get; private set; }
        public Coordinates CurrentCoordinates { get; private set; }

        private readonly string input;

        public MarsRover(char startingDirection)
        {
            CurrentDirection = startingDirection.ToString();
        }

        public MarsRover(string input)
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

        public void SetCurrentDirection(string newDirection)
        {
            CurrentDirection = newDirection;
        }

        private static string[] SplitInputByLines(string input)
        {
            if (!input.Contains("\n"))
            {
                throw new Exception("Error occured while splitting the input: format is incorrect");
            }
            return input.Split('\n');
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
    }
}