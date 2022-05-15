using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Arch.BLL;

namespace Arch.PLL
{
    internal class ConsoleInterface
    {
        private const string AddTriangle = "ADD";
        private static readonly string[] AddTriangleArgs = { "X1", "Y1", "X2", "Y2", "X3", "Y3" };

        private const string GetTriangle = "GET";
        private static readonly string[] GetTriangleArgs = { "ID" };

        private const string ModifyTriangle = "MODIFY";
        private static readonly string[] ModifyTriangleArgs = { "ID", "INDEX", "NEW X", "NEW Y" };

        private const string GetTriangles = "GETALL";

        private const string GetArea = "AREA";
        private static readonly string[] GetAreaArgs = { "ID" };

        private const string GetPerimeter = "PERIMETER";
        private static readonly string[] GetPerimeterArgs = { "ID" };

        private const string DeleteTriangle = "DELETE";
        private static readonly string[] DeleteTriangleArgs = { "ID" };

        private const string Hint = "HINT";
        private const string Clear = "CLEAR";
        private const string Exit = "EXIT";

        private const string UnknownCommand = "UNKNOWN COMMAND";
        private const string WrongArgument = "Wrong argument(s)";

        private static readonly string[] logo_lines = new string[] { "Made by Vladimir Tkachev, 241.", "Please don't break anything :)" };
        private static readonly int maxSyms = logo_lines.Select(x => x.Length).Max() + "|  |".Length;
        private static readonly string Logo = new string('-', maxSyms) + '\n' + string.Join('\n', logo_lines.Select(x => "| " + x + " |")) + '\n' + new string('-', maxSyms);

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
                    Console.Write("cmd> ");
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
                                Console.WriteLine(triangleLogic.Find(int.Parse(arguments[0])));
                            break;

                        case ModifyTriangle:
                            if (arguments.Count != ModifyTriangleArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                triangleLogic.Modify(int.Parse(arguments[0]), int.Parse(arguments[1]), new double[] { double.Parse(arguments[2]), double.Parse(arguments[3]) });
                            break;
                        case GetTriangles:
                            Console.WriteLine(string.Join("\n", triangleLogic.GetAll()));
                            break;

                        case GetArea:
                            if (arguments.Count != GetAreaArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Area(int.Parse(arguments[0])));

                            break;

                        case GetPerimeter:
                            if (arguments.Count != GetPerimeterArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Perimeter(int.Parse(arguments[0])));

                            break;

                        case DeleteTriangle:
                            if (arguments.Count != GetTriangleArgs.Length)
                                Console.WriteLine(WrongArgument);
                            else
                                Console.WriteLine(triangleLogic.Delete(int.Parse(arguments[0])));

                            break;
                        case Hint:
                            Console.WriteLine(GetHint());
                            break;
                        case Clear:
                            Console.Clear();
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
            sb.Append(Logo).Append('\n');
            sb.Append(AddTriangle).Append(": ").Append(string.Join(", ", AddTriangleArgs)).Append('\n');
            sb.Append(GetTriangles).Append('\n');
            sb.Append(ModifyTriangle).Append(": ").Append(string.Join(", ", ModifyTriangleArgs)).Append('\n');
            sb.Append(GetTriangle).Append(": ").Append(string.Join(", ", GetTriangleArgs)).Append('\n');
            sb.Append(GetArea).Append(": ").Append(string.Join(", ", GetAreaArgs)).Append('\n');
            sb.Append(GetPerimeter).Append(": ").Append(string.Join(", ", GetPerimeterArgs)).Append('\n');
            sb.Append(DeleteTriangle).Append(": ").Append(string.Join(", ", DeleteTriangleArgs)).Append('\n');
            sb.Append(Hint).Append('\n');
            sb.Append(Clear).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}
