
using System;
using System.Text.Json.Serialization;

namespace Arch.Enitites
{

    internal class Triangle : IEquatable<Triangle>
    {
        public int Id { get; set; }

        public Point A { get; set;}
        public Point B { get; set;}
        public Point C { get; set;}

        [JsonConstructor]
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override string ToString()
        {
            return string.Format("Triangle №{0} ({1}, {2}):({3}, {4}):({5}, {6})",
                Id,
                A.X, A.Y,
                B.X, B.Y,
                C.X, C.Y);
        }

        public bool Equals(Triangle other) 
        {
            return Id == other.Id && A.Equals(other.A) && B.Equals(other.B) && C.Equals(other.C);
        }
    }
}
