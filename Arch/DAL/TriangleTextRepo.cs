using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

using Arch.Enitites;

namespace Arch.DAL
{
    internal class TriangleTextRepo : ITriangleRepo
    {
        private readonly List<Triangle> triangles;
        private int counter;

        private const string FILE_PATH = "./triangles_textrepo_base.txt";

        public TriangleTextRepo()
        {
            triangles = new List<Triangle>();
            counter = 0;
            if (File.Exists(FILE_PATH))
            {
                string[] lines = File.ReadAllLines(FILE_PATH);
                foreach (string line in lines)
                {
                    Triangle dejs = JsonSerializer.Deserialize<Triangle>(line);
                    counter = dejs.Id;
                    triangles.Add(dejs);
                }
            }
        }

        public Triangle Add(Triangle triangle)
        {
            if (triangle.Id == 0)
            {
                triangle.Id = ++counter;
                triangles.Add(triangle);
                string js = JsonSerializer.Serialize(triangle);
                File.AppendAllText(FILE_PATH, js + "\n");
                return triangle;
            }
            else throw new Exception("Triangle already exist");
        }

        public void Modify(Triangle triangle)
        {
            for (int i = 0; i < triangles.Count; ++i)
                if (triangles[i].Id == triangle.Id)
                {
                    triangles[i] = triangle;
                    break;
                }
            DumpToFile();
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
                    for (int j = i; j < triangles.Count; ++j)
                        --triangles[j].Id;
                    --counter;
                    DumpToFile();
                    return true;
                }

            return false;
        }

        private void DumpToFile()
        {
            File.WriteAllLines(FILE_PATH, triangles.Select(tr => JsonSerializer.Serialize(tr)));
        }
    }
}
