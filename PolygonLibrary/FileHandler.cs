using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{

    /// <summary>
    /// Provide services for file handling.
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// Creates file in the specified path.
        /// <exception cref="UnauthorizedAccessException">
        ///  Throws exception when there is no access to create file specified in the path.
        /// </exception>
        /// </summary>
        /// <param name="path">Path to the file</param>
        public static void createFile(string path)
        {
                File.Create(path).Dispose();
        }

        /// <summary>
        /// Asks if file should be created.
        /// </summary>
        public static bool shouldCreateFile()
        {
            Console.WriteLine("Type c to create file (if there is a permission) or any key to exit");
            string answer = Console.ReadLine();
            if (answer == "c")
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Saves verticies in the specified path.
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// /// <param name="polygon">Polygon to save</param>
        public static void saveVertices(string path, RegularPolygon polygon)
        {
            var verticies = polygon.VerticesCoordinates();

            string[] lines = new string[polygon.VertexNumber];
            for(int i = 0; i < polygon.VertexNumber; i++)
            {
                lines[i] = verticies[i].ToString();
            }
            System.IO.File.WriteAllLines(path, lines);
        }
    }

   
}
