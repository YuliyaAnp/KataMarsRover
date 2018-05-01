using System.Collections.Generic;

namespace MarsRoverKata.Constants
{
    public class Directions
    {
        public const string North = "N";
        public const string South = "S";
        public const string East = "E";
        public const string West = "W";

        public static LinkedList<string> AllowedDirections = new LinkedList<string>(new [] { North, West, South, East });
    }
}
