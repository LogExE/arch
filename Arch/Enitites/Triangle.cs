
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Arch.UnitTests")]

namespace Arch.Enitites
{
    
    internal class Triangle : IEquatable<Triangle>
    {
        public int Id { get; set; }

        public Point[] Points { get; set; }

        public Triangle()
        {
            Points = new Point[3];
        }

        public override string ToString()
        {
            return string.Format("Triangle №{0} ({1}, {2}):({3}, {4}):({5}, {6})",
                Id,
                Points[0].X, Points[0].Y,
                Points[1].X, Points[1].Y,
                Points[2].X, Points[2].Y);
        }

        public bool Equals(Triangle other) 
        {
            return Id == other.Id && Points[0].Equals(other.Points[0]) && Points[1].Equals(other.Points[1]) && Points[2].Equals(other.Points[2]);
        }
    }
}
