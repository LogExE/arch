using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arch.Enitites
{
    internal class Triangle
    {
        public int Id { get; set; }

        public Point[] points;

        public override string ToString()
        {
            return "Triangle " + Id;
        }
    }
}
