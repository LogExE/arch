using System;

using Arch.PLL;
using Arch.BLL;
using Arch.DAL;

namespace Arch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITriangleRepo triangleRepo = new TriangleMemoryRepo();
            ITriangleLogic triangleLogic = new TriangleLogicImpl(triangleRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(triangleLogic);
            consoleInterface.Start();
        }
    }
}
