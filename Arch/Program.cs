
using Arch.PLL;
using Arch.BLL;
using Arch.DAL;

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Arch.UnitTests")]

namespace Arch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITriangleRepo triangleRepo = new TriangleTextRepo();
            ITriangleLogic triangleLogic = new TriangleLogicImpl(triangleRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(triangleLogic);
            consoleInterface.Start();
        }
    }
}
