using System;
using System.Collections.Generic;
using MarsRoverKata.Constants;

namespace MarsRoverKata.Navigation
{
    public class MovingControl
    {
        private readonly Dictionary<string, Func<Coordinates, Coordinates>> moveFunctions =
                                new Dictionary<string, Func<Coordinates, Coordinates>>
        {
            { Directions.North, MoveNorth },
            { Directions.West, MoveWest },
            { Directions.South, MoveSouth },
            { Directions.East, MoveEast }
        };

        public Coordinates Move(char command, string currentDirection, Coordinates currentCoordinates)
        {
            if (command == Commands.Move)
            {
                return moveFunctions[currentDirection](currentCoordinates);
            }

            return currentCoordinates;
        }

        private static Coordinates MoveEast(Coordinates coordinates)
        {
            return new Coordinates
            {
                X = coordinates.X + 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveSouth(Coordinates coordinates)
        {
            return new Coordinates
            {
                X = coordinates.X,
                Y = coordinates.Y - 1
            };
        }

        private static Coordinates MoveWest(Coordinates coordinates)
        {
            return new Coordinates
            {
                X = coordinates.X - 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveNorth(Coordinates coordinates)
        {
            return new Coordinates
            {
                X = coordinates.X,
                Y = coordinates.Y + 1
            };
        }
    }
}