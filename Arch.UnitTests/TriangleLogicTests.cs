
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using Arch.BLL;
using Arch.DAL;
using Arch.Enitites;

namespace Arch.UnitTests
{
    [TestClass]
    public class TriangleLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Triangle is degenerate")]
        public void DegenerateTriangleException()
        {
            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);

            logic.Create(new double[]{ 0, 0, 0, 1, 0, 2}); //should throw
        }

        [TestMethod]
        public void ValidTriangleCreation()
        {
            var expectedTriangle = new Triangle();
            expectedTriangle.Points[0] = new Point(0, 0);
            expectedTriangle.Points[1] = new Point(0, 1);
            expectedTriangle.Points[2] = new Point(1, 0);
            expectedTriangle.Id = 1;

            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var triangle = logic.Create(new double[] { 0, 0, 0, 1, 1, 0 });

            Assert.IsTrue(triangle.Equals(expectedTriangle));
        }

        [TestMethod]
        public void ValidTriangleDeletion()
        {
            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var id = logic.Create(new double[] { 1, 3, 0, 2, 1, 0 }).Id;
            logic.Delete(id);

            Assert.IsTrue(logic.GetAll().Count == 0);
        }

        [TestMethod]
        public void ValidTriangleArea()
        {
            double expectedArea = 13.5;

            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var id = logic.Create(new double[] { 2, 2, 4, 5, 11, 2 }).Id;
            double realArea = logic.Area(id);

            Assert.IsTrue(Math.Abs(realArea - expectedArea) < 1e-9);
        }

        [TestMethod]
        public void ValidTrianglePerimeter()
        {
            double expectedPerimeter = 4 + Math.Sqrt(8);

            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var id = logic.Create(new double[] { 0, 0, 2, 2, 2, 0 }).Id;
            double realPerimeter = logic.Perimeter(id);

            Assert.IsTrue(Math.Abs(realPerimeter - expectedPerimeter) < 1e-9);
        }
    }
}
