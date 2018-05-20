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
    public class VertexTests
    {

        [TestMethod()]
        public void Equals_ShouldReturnTrue()
        {
            Assert.IsTrue(new Vertex(1.1, 1).Equals(new Vertex(1.1, 1)));
        }
        [TestMethod()]
        public void Equals_ShouldReturnFalse()
        {
            Assert.IsFalse(new Vertex(0, 0).Equals(new Vertex(1, 0)));
        }
    }
}