
namespace Arch.Enitites
{
    internal class Triangle
    {
        public int Id { get; set; }

        public Point[] points { get; set; }

        public override string ToString()
        {
            return string.Format("Triangle №{0} ({1}, {2}):({3}, {4}):({5}, {6})",
                Id,
                points[0].X, points[0].Y,
                points[1].X, points[1].Y,
                points[2].X, points[2].Y);
        }
    }
}
