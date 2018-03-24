using System;

namespace MarsRoverKata
{
    public class MarsRover
    {
        public NavigationParameters NavigationParameters { get; private set; }
        public string FinalPosition { get; private set; }

        private string currentDirection;
        private string command;
        private Coordinates plateauDimenstions;
        private Coordinates currentCoordinates;
        private readonly string input;
        private MarsRoverNavigator marsRoverNavigator;
        
        public MarsRover(string input)
        {
            this.input = input;
        }

        public void Initialize()
        {
            string[] inputByLines = SplitInputByLines(input);
            SetPlateauDimensions(inputByLines);
            SetCurrentPositionAndDirection(inputByLines);
            command = inputByLines[2];

            NavigationParameters = new NavigationParameters(currentDirection, plateauDimenstions, currentCoordinates, command);
        }
        public void Navigate()
        {
            marsRoverNavigator = new MarsRoverNavigator(NavigationParameters);
            FinalPosition = marsRoverNavigator.Navigate();
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

            plateauDimenstions = new Coordinates
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

            currentCoordinates = new Coordinates
            {
                X = Int32.Parse(stringCurrentPositionAndDirection[0]),
                Y = Int32.Parse(stringCurrentPositionAndDirection[1])
            };

            currentDirection = stringCurrentPositionAndDirection[2];
        }
    }
}