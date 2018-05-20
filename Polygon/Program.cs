using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolygonLibrary;

namespace PolygonConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int maxNumberOfInputArguments = 3;
            int minNumberOfInputArguments = 2;

            if(!InputValidationMethods.Validate(args, maxNumberOfInputArguments, minNumberOfInputArguments))
                return;

            int vertexCount = Convert.ToInt32(args[0]);
            double sideLength = Convert.ToDouble(args[1]);

            RegularPolygon polygon;
            try
            {
                polygon = RegularPolygonFactory.createRegularPolygon(vertexCount, sideLength);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            if(args.Length == maxNumberOfInputArguments)
                FileHandler.saveVertices(args[2], polygon);
            else
                Console.WriteLine(polygon.ToString());

            Console.ReadKey();

        }

    }
}
