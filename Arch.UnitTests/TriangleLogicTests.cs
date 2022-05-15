
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

            //should raise an exception
            logic.Create(new double[]{ 0, 0, 0, 12.5, 0, 25});
        }

        [TestMethod]
        public void ValidTriangleCreation()
        {
            var expectedTriangle = new Triangle(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            expectedTriangle.Id = 1;

            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var triangle = logic.Create(new double[] { 0, 0, 0, 1, 1, 0 });

            Assert.IsTrue(triangle.Equals(expectedTriangle));
        }

        [TestMethod]
        public void ValidTriangleModification()
        {
            var expectedTriangle1 = new Triangle(new Point(0, 32), new Point(0, 1), new Point(1, 0));
            var expectedTriangle2 = new Triangle(new Point(0, 0), new Point(21.72, 1), new Point(1, 0));
            var expectedTriangle3 = new Triangle(new Point(0, 0), new Point(0, 1), new Point(54, 54));
            expectedTriangle1.Id = 1;
            expectedTriangle2.Id = 2;
            expectedTriangle3.Id = 3;

            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var id1 = logic.Create(new double[] { 0, 0, 0, 1, 1, 0 }).Id;
            var id2 = logic.Create(new double[] { 0, 0, 0, 1, 1, 0 }).Id;
            var id3 = logic.Create(new double[] { 0, 0, 0, 1, 1, 0 }).Id;
            logic.Modify(id1, 1, new double[] { 0, 32 });
            logic.Modify(id2, 2, new double[] { 21.72, 1 });
            logic.Modify(id3, 3, new double[] { 54, 54 });
            var triangleMod1 = logic.Find(id1);
            var triangleMod2 = logic.Find(id2);
            var triangleMod3 = logic.Find(id3);

            Assert.IsTrue(triangleMod1.Equals(expectedTriangle1) && triangleMod2.Equals(expectedTriangle2) && triangleMod3.Equals(expectedTriangle3));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Triangle would be degenerate")]
        public void InvalidTriangleModification()
        {
            var repo = new TriangleMemoryRepo();
            var logic = new TriangleLogicImpl(repo);
            var id = logic.Create(new double[] { 10, 15, 12.5, 18.134, 16.3, 18.134 }).Id;

            //bad modification
            logic.Modify(id, 1, new double[] { 10, 18.134 });
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
