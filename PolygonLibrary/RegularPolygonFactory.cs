using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    public static class  RegularPolygonFactory
    {
        /// <summary>
        /// Returns regular polygon with calculated (by RegularPolygonCalculator) values.
        /// </summary>
        /// <param name="vertexNumber"></param>
        /// <param name="sideLength"></param>
        /// <returns></returns>
        public static RegularPolygon createRegularPolygon(int vertexNumber, double sideLength)
        {
            if (vertexNumber < 3)
                throw new ArgumentException("There should be at least 3 verticies");

            RegularPolygon polygon = new RegularPolygon
            (
                RegularPolygonCalculator.calculateArea(vertexNumber, sideLength),
                vertexNumber,
                RegularPolygonCalculator.calculateVerticesCoordinates(sideLength, vertexNumber)
            );
            return polygon;
        }
    }
}
