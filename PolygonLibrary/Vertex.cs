using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    /// <summary>
    /// Represents vertex coordinates.
    /// </summary>
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        /// <summary>
        /// Compares two vertices.
        /// </summary>
        /// <param name="other">Other vertex</param>
        /// <returns></returns>
        public bool Equals(Vertex other)
        {
            if (this.X == other.X && this.Y == other.Y)
                return true;
            else
                return false;
        }
    }
}
