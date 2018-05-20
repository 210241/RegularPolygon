using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    /// <summary>
    /// Provides methods to calculate area and verticies of regular polygon.
    /// </summary>
    public static class  RegularPolygonCalculator
    {
        /// <summary>
        /// Calculates area of regular polygon based on perimiter and apothem.
        /// </summary>
        /// <param name="sideNumber">Number of sides (verticies)</param>
        /// <param name="sideLength">Side length</param>
        /// <returns></returns>
        public static double calculateArea(double sideNumber, double sideLength)
        {       
            double perimiter = sideNumber * sideLength;
            double apothem = sideLength / (2 * Math.Tan(Math.PI / sideNumber));
            double area = (apothem * perimiter) / 2;
            return Math.Round(area, 2);
        }

        /// <summary>
        /// Calculates verticies coordinates. 
        /// Ensures that the first vertex will have (0,0) coordinates.
        /// </summary>
        /// <param name="sideLength">Side length</param>
        /// <param name="vertexNumber">Number of verticies (sides)</param>
        /// <returns></returns>
        public static Vertex[] calculateVerticesCoordinates(double sideLength, int vertexNumber)
        {
            double apothem = sideLength / (2 * Math.Tan(Math.PI / vertexNumber));

            Vertex[] verticesCoordinates = new Vertex[vertexNumber];
            //double radius = sideLength / (2 * Math.Sin(180 / vertexNumber));//TODO: check if correct
            double radius = sideLength / (2 * Math.Sin(Math.PI/ vertexNumber));

            double a = radius * Math.Sin(Math.PI / vertexNumber);
            double b = radius * Math.Cos(Math.PI / vertexNumber);

            double x, y;
            for (int i = 0; i < vertexNumber; i++)
            {
                x = Math.Round(a - radius * Math.Sin((Math.PI / vertexNumber) * (1 + 2 * i)), 2);
                y = Math.Round(b - radius * Math.Cos((Math.PI / vertexNumber) * (1 + 2 * i)), 2);
                verticesCoordinates[i] = new Vertex(x,y);
            }
            return verticesCoordinates;
        }
    }
}
