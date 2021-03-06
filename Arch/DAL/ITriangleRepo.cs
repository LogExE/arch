using System.Collections.Generic;

using Arch.Enitites;

namespace Arch.DAL
{
    internal interface ITriangleRepo
    {
        Triangle Add(Triangle triangle);

        void Modify(Triangle triangle);

        List<Triangle> GetAll();

        bool Delete(int id);
    }
}
