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
    public class InputValidationMethodsTests
    {
        
        [TestMethod()]
        public void isArgumentsAmountCorrect_ShouldReturnTrue()
        {
            int numberOfArguments = 2  ;
            int minNumberOfArguments = 1;
            int maxNumberOfArguments = 2;

            try
            {
                InputValidationMethods.isArgumentsAmountCorrect(numberOfArguments, maxNumberOfArguments, minNumberOfArguments);
                Assert.IsTrue(true);
            }
            catch(ArgumentException)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentsAmountCorrect_TooManyArguments_ShouldThrowException()
        {
            int numberOfArguments = 3;
            int minNumberOfArguments = 1;
            int maxNumberOfArguments = 2;

            InputValidationMethods.isArgumentsAmountCorrect(numberOfArguments, maxNumberOfArguments, minNumberOfArguments);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentsAmountCorrect_TooLittleArguments_ShouldThrowException()
        {
            int numberOfArguments = 0;
            int minNumberOfArguments = 1;
            int maxNumberOfArguments = 2;

            InputValidationMethods.isArgumentsAmountCorrect(numberOfArguments, maxNumberOfArguments, minNumberOfArguments);
        }

        [TestMethod()]
        public void isArgumentCorrectNumber_Double_ShouldReturnTrue()
        {
            try
            {
                InputValidationMethods.isArgumentCorrectNumber("1.1", typeof(double));
                Assert.IsTrue(true);
            }
            catch(ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void isArgumentCorrectNumber_Integer_ShouldReturnTrue()
        {
            try
            {
                InputValidationMethods.isArgumentCorrectNumber("1", typeof(int));
                Assert.IsTrue(true);
            }
            catch (ArgumentException)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentCorrectNumber_TextInstedOfDoubleNumber_ShouldThrowException()
        {
                InputValidationMethods.isArgumentCorrectNumber("text", typeof(double));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentCorrectNumber_TextInstedOfIntegerNumber_ShouldThrowException()
        {
            InputValidationMethods.isArgumentCorrectNumber("text", typeof(int));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentCorrectNumber_TextInstedOfIntNumber_ShouldThrowException()
        {
            InputValidationMethods.isArgumentCorrectNumber("text", typeof(int));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentCorrectNumber_NegtiveNumberDouble_ShouldThrowException()
        {
            InputValidationMethods.isArgumentCorrectNumber("-2.2", typeof(double));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void isArgumentCorrectNumber_NegtiveNumberInt_ShouldThrowException()
        {
            InputValidationMethods.isArgumentCorrectNumber("-2", typeof(int));
        }

    }
}