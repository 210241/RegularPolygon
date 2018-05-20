using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    public class FileHandlerNoFileException : Exception
    {
        public FileHandlerNoFileException(string message) : base(message)
        {

        }
    }
}
