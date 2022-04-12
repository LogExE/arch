using System.Collections.Generic;

using Arch.Enitites;

namespace Arch.BLL
{
    internal interface ITriangleLogic
    {
        Triangle Create(double[] coords);

        List<Triangle> GetAll();

        double Area(int id);

        double Perimeter(int id);

        bool Delete(int id);

        Triangle Find(int id);
    }
}
