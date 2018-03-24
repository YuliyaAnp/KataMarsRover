using System;
using System.Collections.Generic;

namespace MarsRoverKata
{
    public class MovingControl
    {
        public Dictionary<string, Func<Coordinates, Coordinates>> MoveFunctions =
                                new Dictionary<string, Func<Coordinates, Coordinates>>
        {
            {"N", MoveNorth},
            {"W", MoveWest},
            {"S", MoveSouth},
            {"E", MoveEast}
        };

        private static Coordinates MoveEast(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X + 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveSouth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y - 1
            };
        }

        private static Coordinates MoveWest(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X - 1,
                Y = coordinates.Y
            };
        }

        private static Coordinates MoveNorth(Coordinates coordinates)
        {
            return new Coordinates()
            {
                X = coordinates.X,
                Y = coordinates.Y + 1
            };
        }
    }
}