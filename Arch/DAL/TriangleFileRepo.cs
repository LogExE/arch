using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Arch.Enitites;

namespace Arch.DAL
{
    internal class TriangleFileRepo : ITriangleRepo
    {
        private readonly List<Triangle> triangles;
        private int counter;
        private const string path = "./db.txt";
        FileStream fileStream;
        StreamReader reader;
        StreamWriter writer;

        public TriangleFileRepo()
        {
            triangles = new List<Triangle>();
            counter = 0;
            fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            reader = new StreamReader(fileStream);
            writer = new StreamWriter(fileStream);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Triangle dejsonified = JsonSerializer.Deserialize<Triangle>(line);
                dejsonified.Id = ++counter;
                triangles.Add(dejsonified);
            }
        }

        public Triangle Add(Triangle triangle)
        {
            if (triangle.Id == 0)
            {
                triangle.Id = ++counter;
                triangles.Add(triangle);
                string jsonified = JsonSerializer.Serialize(triangle);
                writer.WriteLine(jsonified);
                writer.Flush();
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
