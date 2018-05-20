using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary.Tests
{
    [TestClass()]
    public class RegularPolygonCalculatorTests
    {
        [TestMethod()]
        public void calculateAreaTest_ShouldBeEqual()
        {
            Assert.AreEqual(Math.Sqrt(3), RegularPolygonCalculator.calculateArea(3, 2), 0.01);
        }

        [TestMethod()]
        public void calculateVerticesCoordinatesTest()
        {
            Vertex[] verticies = new Vertex[3];
            verticies = RegularPolygonCalculator.calculateVerticesCoordinates(2, 3);

            Assert.IsTrue(verticies[0].Equals(new Vertex(0, 0)));
            Assert.IsTrue(verticies[1].Equals(new Vertex(1, 1.73)));
            Assert.IsTrue(verticies[2].Equals(new Vertex(2, 0)));
        }
    }
}