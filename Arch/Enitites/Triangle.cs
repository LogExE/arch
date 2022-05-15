
namespace Arch.Enitites
{
    internal class Triangle
    {
        public int Id { get; set; }

        public Point[] Points { get; set; }

        public override string ToString()
        {
            return string.Format("Triangle №{0} ({1}, {2}):({3}, {4}):({5}, {6})",
                Id,
                Points[0].X, Points[0].Y,
                Points[1].X, Points[1].Y,
                Points[2].X, Points[2].Y);
        }
    }
}
