using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Arch.UnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void CantBeCreatedWithZeroArea()
        {
            var triangle = new Triangle();
        }
    }
}
