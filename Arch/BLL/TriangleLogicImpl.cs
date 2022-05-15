using System;
using System.Collections.Generic;

using Arch.DAL;
using Arch.Enitites;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Arch.UnitTests")]

namespace Arch.BLL
{
    internal class TriangleLogicImpl : ITriangleLogic
    {
        private ITriangleRepo triangleRepo;
        public TriangleLogicImpl(ITriangleRepo triangleRepo)
        {
            this.triangleRepo = triangleRepo;
        }
        public Triangle Create(double[] coords)
        {
            Triangle triangle = new Triangle();
            triangle.Points[0] = new Point(coords[0], coords[1]); 
            triangle.Points[1] = new Point(coords[2], coords[3]);
            triangle.Points[2] = new Point(coords[4], coords[5]);

            if (Area(triangle) < 1e-9)
                throw new Exception("Triangle is degenerate");

            return triangleRepo.Add(triangle);
        }

        public List<Triangle> GetAll()
        {
            return triangleRepo.GetAll();
        }

        private double Area(Triangle triangle)
        {         
            Point a = triangle.Points[0];
            Point b = triangle.Points[1];
            Point c = triangle.Points[2];

            return Math.Abs(a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2;
        }

        public double Area(int id)
        {
            Triangle triangle = Find(id);

            return Area(triangle);
        }

        public double Perimeter(int id)
        {
            Triangle triangle = Find(id);

            Point a = triangle.Points[0];
            Point b = triangle.Points[1];
            Point c = triangle.Points[2];

            double len1 = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            double len2 = Math.Sqrt((b.X - c.X) * (b.X - c.X) + (b.Y - c.Y) * (b.Y - c.Y));
            double len3 = Math.Sqrt((a.X - c.X) * (a.X - c.X) + (a.Y - c.Y) * (a.Y - c.Y));

            return len1 + len2 + len3;
        }

        public bool Delete(int id) 
        { 
            return triangleRepo.Delete(id);
        }

        public Triangle Find(int id)
        {
            foreach (Triangle triangle in triangleRepo.GetAll())
                if (triangle.Id == id)
                    return triangle;

            return null;
        }
    }
}
