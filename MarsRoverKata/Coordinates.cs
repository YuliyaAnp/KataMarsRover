namespace MarsRoverKata
{
    public class Coordinates
    {
        protected bool Equals(Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Coordinates) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Coordinates left, Coordinates right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coordinates left, Coordinates right)
        {
            return !Equals(left, right);
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}