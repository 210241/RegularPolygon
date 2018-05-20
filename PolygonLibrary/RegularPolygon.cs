using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    /// <summary>
    /// Represents regular polygon.
    /// All properties are readonly to ensure static state of polygon.
    /// </summary>
    public class RegularPolygon
    {
        private double _area;
        private int _vertexNumber;

        /// <summary>
        /// Represents verticies coordinates
        /// </summary>
        private readonly Vertex[] verticesCoordinates;

        /// <summary>
        /// Property that represents calculated area of polygon
        /// </summary>
        public double Area { get => _area; }

        /// <summary>
        /// Property that represents number of verticies which is equal to number of sides
        /// </summary>
        public int VertexNumber { get => _vertexNumber; }


        /// <summary>
        /// Creats polygon. To ensure unchangeable verticies table, creats its copy.
        /// </summary>
        /// <param name="area">Area</param>
        /// <param name="vertexNumber">Number of verticies(sides)</param>
        /// <param name="vertices">Verticies coordinates table</param>
        public RegularPolygon(double area, int vertexNumber, Vertex[] vertices)
        {
            _area = area;
            _vertexNumber = vertexNumber;

            verticesCoordinates = new Vertex[vertexNumber];
            Array.Copy(vertices, verticesCoordinates, vertexNumber);
        }

        public Vertex[] VerticesCoordinates()
        {
            Vertex[] temp = new Vertex[_vertexNumber];
            Array.Copy(verticesCoordinates, temp, _vertexNumber);
            return temp;
        }



        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Area:" + Area);
            builder.AppendLine("Vertices: ");
            foreach(Vertex vertex in verticesCoordinates)
            {
                builder.AppendLine(vertex.ToString());
            }

            return builder.ToString();
        }
    }
}
