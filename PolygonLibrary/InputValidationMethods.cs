using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLibrary
{
    /// <summary>
    /// Provides all validation methods and complex validation method.
    /// </summary>
    public static class InputValidationMethods
    {

        /// <summary>
        /// Performs all validation methods. 
        /// In case of no file in specified path asks if should be created and (if it is possible) creates file.
        /// </summary>
        /// <param name="args">Whole program input</param>
        /// <param name="maxNumberOfInputArguments">Maximal number of input arguments</param>
        /// <param name="minNumberOfInputArguments">Minimal number of input arguments</param>
        /// <returns></returns>
        public static bool Validate(String[] args, int maxNumberOfInputArguments, int minNumberOfInputArguments)
        {
            string exit = "Press any key to exit...";
            try
            {
                InputValidationMethods.isArgumentsAmountCorrect(args.Length, maxNumberOfInputArguments, minNumberOfInputArguments);
                InputValidationMethods.isArgumentCorrectNumber(args[0], typeof(int));
                InputValidationMethods.isArgumentCorrectNumber(args[1], typeof(double));

                string path = args[2];
                try
                {
                    
                    if (args.Length == maxNumberOfInputArguments)
                    {
                        InputValidationMethods.IsPathValid(path);
                        InputValidationMethods.isThereFile(path);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(exit);
                    Console.ReadKey();
                    return false;
                }
                catch (FileHandlerNoFileException e)
                {
                    Console.WriteLine(e.Message);
                    if (FileHandler.shouldCreateFile())
                    {
                        try
                        {
                            FileHandler.createFile(path);
                            return true;
                        }
                        catch(UnauthorizedAccessException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(exit);
                            Console.ReadKey();
                            return false;
                        }
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(exit);
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// Chcecks if there is correct arguments amount.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws exception when there is too little or too many arguments
        /// </exception>
        /// <param name="argumentsNumber"> Number of input arguments</param>
        /// <param name="maxInputNumber">Maximal number of input arguments</param>
        /// <param name="minInputNumber">Minimal number of input arguments</param>
        public static void isArgumentsAmountCorrect(int argumentsNumber, int maxInputNumber, int minInputNumber)
        {
            if (argumentsNumber > maxInputNumber)
            {
                throw new ArgumentException("Too many arguments.There should be no more then " + maxInputNumber + ".");
            }
            else if (argumentsNumber < minInputNumber)
            { 
                throw new ArgumentException("Too little arguments. There should be at least " + minInputNumber + ".");
            }
        }

        /// <summary>
        /// Chcecks if argument is number and is not negative.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws exception when cannot parse or number is negative.
        /// </exception>
        /// <param name="numberText">String representing number</param>
        /// <param name="type">Expected type of number</param>
        public static void isArgumentCorrectNumber(string numberText, Type type)
        {
            double doubleNumber = 0;
            int intNumber = 0;

            if (type == typeof(double))
            {
                if (!Double.TryParse(numberText, out doubleNumber))
                {
                    throw new ArgumentException("One of arguments is not a valid number");
                }
                else
                {
                    if (doubleNumber <= 0)
                        throw new ArgumentException("One of arguments is negative number");
                }
            }

            if (type == typeof(int))
            {
                if (!Int32.TryParse(numberText, out intNumber))
                {
                    throw new ArgumentException("One of arguments is not a valid number");
                }
                else
                {
                    if (intNumber <= 0)
                        throw new ArgumentException("One of arguments is negative number");
                }
            }
        }

        /// <summary>
        /// Checks if file exists.
        /// </summary>
        /// <exception cref ="FileHandlerNoFileException" >
        /// Throws exception when file does not exist.
        /// </exception>
        /// <param name="path">Path to the file</param>
        public static void isThereFile(string path)
        {
            if (!(File.Exists(path)))
            {
                throw new FileHandlerNoFileException("There is no such file");
            }            
        }

        /// <summary>
        ///  Validates path.
        /// </summary>
        /// <exception cref ="ArgumentException" >
        /// Throws exception when file does not meet criteria.
        /// </exception>
        /// <param name="path">Path to the file</param>
        public static void IsPathValid(string path)
        {
            try
            {
                path = path.Replace(@"\\", ":"); // to cancel out c:\\\\test.text
                string tmpPath = Path.GetPathRoot(path); //For cases like: \text.txt
                if (tmpPath.StartsWith(@"\"))
                    throw new ArgumentException("Path is invalid");
                tmpPath = Path.GetFullPath(path);
            }
            catch //Possible exceptions: ArgumentException, SecurityException, ArgumentNullException, NotSupportedException, PathTooLongException
            {
                throw new ArgumentException("Path is invalid");
            }
        }
    }


}
