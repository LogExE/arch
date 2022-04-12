using System;
using System.Text;
using System.Collections.Generic;

using Arch.BLL;

namespace Arch.PLL
{
    internal class ConsoleInterface
    {
        private const string AddTriangle = "ADD";
        private static readonly string[] AddTriangleArgs = { "x1", "y1", "x2", "y2", "x3", "y3" };

        private const string GetTriangle = "GET";
        private static readonly string[] GetTriangleArgs = { "ID" };

        private const string GetTriangles = "GETALL";

        private const string GetArea = "AREA";
        private static readonly string[] GetAreaArgs = { "ID" };

        private const string GetPerimeter = "PERIMETER";
        private static readonly string[] GetPerimeterArgs = { "ID" };

        private const string DeleteTriangle = "DELETE";
        private static readonly string[] DeleteTriangleArgs = { "ID" };

        private const string Hint = "HINT";
        private const string Exit = "EXIT";

        private const string UnknownCommand = "UNKNOWN COMMAND";
        private const string WrongArgument = "Wrong argument(s)";

        private readonly ITriangleLogic triangleLogic;

        public ConsoleInterface(ITriangleLogic triangleLogic)
        {
            this.triangleLogic = triangleLogic;
        }

        public void Start()
        {
            Console.WriteLine(GetHint());
            for (;;)
            {
                try
                {
                    Console.Write("? ");
                    List<string> arguments = new List<string>(Console.ReadLine().Split(" "));
                    string command = arguments[0].ToUpper();
                    arguments.RemoveAt(0);
                    switch (command)
                    {
                        case AddTriangle:
                            if (arguments.Count != AddTriangleArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Create(Array.ConvertAll(arguments.ToArray(), x => double.Parse(x))));

                            break;
                        case GetTriangle:
                            if (arguments.Count != GetTriangleArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Find(Convert.ToInt32(arguments[0])));

                            break;
                        case GetTriangles:
                            Console.WriteLine(String.Join("\n", triangleLogic.GetAll()));
                            break;

                        case GetArea:
                            if (arguments.Count != GetAreaArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Area(Convert.ToInt32(arguments[0])));

                            break;

                        case GetPerimeter:
                            if (arguments.Count != GetPerimeterArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Perimeter(Convert.ToInt32(arguments[0])));

                            break;

                        case DeleteTriangle:
                            if (arguments.Count != GetTriangleArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Delete(Convert.ToInt32(arguments[0])));

                            break;
                        case Hint:
                            Console.WriteLine(GetHint());
                            break;
                        case Exit:
                            return;
                        default:
                            Console.WriteLine(UnknownCommand);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static string GetHint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AddTriangle).Append(": ").Append(string.Join(", ", AddTriangleArgs)).Append('\n');
            sb.Append(GetTriangles).Append('\n');
            sb.Append(GetTriangle).Append(": ").Append(string.Join(", ", GetTriangleArgs)).Append('\n');
            sb.Append(GetArea).Append(": ").Append(string.Join(", ", GetAreaArgs)).Append('\n');
            sb.Append(GetPerimeter).Append(": ").Append(string.Join(", ", GetPerimeterArgs)).Append('\n');
            sb.Append(DeleteTriangle).Append(": ").Append(string.Join(", ", DeleteTriangleArgs)).Append('\n');
            sb.Append(Hint).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}
