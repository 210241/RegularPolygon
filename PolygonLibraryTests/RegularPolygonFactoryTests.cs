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
    public class RegularPolygonFactoryTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateRegularPolygon_InappropriateAmountOfVertices_ShouldThrowException()
        {
            RegularPolygon polygon = RegularPolygonFactory.createRegularPolygon(1,2);
        }

        [TestMethod()]   
        public void CreateRegularPolygon_ValidInput_ShouldReturnCorrectValue()
        {
            RegularPolygon polygon = RegularPolygonFactory.createRegularPolygon(3, 2);

            Assert.AreEqual(3, polygon.VertexNumber);
            Assert.AreEqual(Math.Sqrt(3),polygon.Area, 0.01);
            Assert.AreEqual(3, polygon.VerticesCoordinates().Length);
        }

        [TestMethod()]
        public void CreateRegularPolygon_Pentagon_ShouldReturnCorrectVerticies()
        {
            RegularPolygon polygon = RegularPolygonFactory.createRegularPolygon(5, 2);

            var verticies = polygon.VerticesCoordinates();

            Assert.IsTrue(verticies[0].Equals(new Vertex(0, 0)));
            Assert.IsTrue(verticies[1].Equals(new Vertex(-0.62, 1.9)));
            Assert.IsTrue(verticies[2].Equals(new Vertex(1, 3.08)));
            Assert.IsTrue(verticies[3].Equals(new Vertex(2.62, 1.9)));
            Assert.IsTrue(verticies[4].Equals(new Vertex(2, 0)));
        }




    }
}