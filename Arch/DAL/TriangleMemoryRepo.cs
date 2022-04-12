using System;
using System.Collections.Generic;

using Arch.Enitites;

namespace Arch.DAL
{
    internal class TriangleMemoryRepo : ITriangleRepo
    {
        private readonly List<Triangle> triangles;
        private int counter;

        public TriangleMemoryRepo()
        {
            triangles = new List<Triangle>();
            counter = 0;
        }

        public Triangle Add(Triangle triangle)
        {
            if (triangle.Id == 0)
            {
                triangle.Id = ++counter;
                triangles.Add(triangle);
                return triangle;
            }
            else throw new Exception("Triangle already exist");
        }

        public List<Triangle> GetAll()
        {
            return triangles;
        }

        public bool Delete(int id)
        {
            for (int i = 0; i < triangles.Count; ++i)
                if (triangles[i].Id == id)
                {
                    triangles.RemoveAt(i);
                    return true;
                }

            return false;
        }
    }
}
