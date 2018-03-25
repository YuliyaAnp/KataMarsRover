using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public NavigationParameters NavigationParameters { get; private set; }
        public string FinalPosition { get; private set; }

        private readonly string input;
        private Coordinates plateauDimenstions;
        private Coordinates currentCoordinates;
        private string currentDirection;
        private string command;

        private const int expectedNumberOfInputLines = 3;
        private const int expectedLineWithPlateauDimension = 0;
        private const int expectedLineWithStartPosition = 1;
        private const int expectedLineWithCommand = 2;
        private const char linesDelimeter = '\n';
        private const char parametersDelimeter = ' ';
        private const string incorrectInputFormatErrorMessage = "Error occured while splitting the input: format is incorrect";
        private const string incorrectPlateauDimensionsErrorMessage = "Plateau dimensions should contain two int parameters: x and y";
        private const string incorrectStartPositionErrorMessage = "Start position and direction should contain three parameters: int x, int y and direction (N, S, W or E)";
        private MarsRoverNavigator marsRoverNavigator;
        private List<string> allowedDirections = new List<string> { "N", "W", "E", "S" };
        
        public MarsRover(string input)
        {
            this.input = input;
        }

        public void Initialize()
        {
            string[] inputByLines = SplitInputByLines(input);
            SetPlateauDimensions(inputByLines);
            SetStartPositionAndDirection(inputByLines);
            command = inputByLines[expectedLineWithCommand];

            NavigationParameters = new NavigationParameters(currentDirection, plateauDimenstions, currentCoordinates, command);
        }

        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(NavigationParameters);
            FinalPosition = marsRoverNavigator.Navigate();
        }

        private static string[] SplitInputByLines(string input)
        {
            var splitString = input.Split(linesDelimeter);

            if (splitString.Length != expectedNumberOfInputLines)
            {
                throw new Exception(incorrectInputFormatErrorMessage);
            }

            return splitString;
        }

        private void SetPlateauDimensions(string[] inputLines)
        {
            var stringPlateauDimenstions = inputLines[expectedLineWithPlateauDimension].Split(parametersDelimeter);

            if (PlateauDimensionsAreInvalid(stringPlateauDimenstions))
            {
                throw new ArgumentException(incorrectPlateauDimensionsErrorMessage);
            }

            plateauDimenstions = new Coordinates
            {
                X = Int32.Parse(stringPlateauDimenstions[0]),
                Y = Int32.Parse(stringPlateauDimenstions[1])
            };
        }

        private bool PlateauDimensionsAreInvalid(string[] stringPlateauDimenstions)
        {
            if (stringPlateauDimenstions.Length != 2 || !stringPlateauDimenstions[0].All(char.IsDigit) 
                || !stringPlateauDimenstions[1].All(char.IsDigit))
            {
                return true;
            }

            return false;
        }

        private void SetStartPositionAndDirection(string[] inputByLines)
        {
            var stringCurrentPositionAndDirection = inputByLines[expectedLineWithStartPosition].Split(parametersDelimeter);

            if (StartPositionIsInvalid(stringCurrentPositionAndDirection))
            {
                throw new ArgumentException(incorrectStartPositionErrorMessage);
            }

            currentCoordinates = new Coordinates
                {
                    X = Int32.Parse(stringCurrentPositionAndDirection[0]),
                    Y = Int32.Parse(stringCurrentPositionAndDirection[1])
                };

            currentDirection = stringCurrentPositionAndDirection[2]; 
        }

        private bool StartPositionIsInvalid(string[] stringCurrentPositionAndDirection)
        {
            if (stringCurrentPositionAndDirection.Length != 3 || !stringCurrentPositionAndDirection[0].All(char.IsDigit)
                || !stringCurrentPositionAndDirection[1].All(char.IsDigit) || !allowedDirections.Any(stringCurrentPositionAndDirection[2].Contains))
            {
                return true;
            }

            if (Int32.Parse(stringCurrentPositionAndDirection[0]) > plateauDimenstions.X || 
                Int32.Parse(stringCurrentPositionAndDirection[1]) > plateauDimenstions.Y)
            {
                return true;
            }

            return false;
        }
    }
}