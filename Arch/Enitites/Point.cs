
using System;

namespace Arch.Enitites
{
    internal class Point : IEquatable<Point>
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
