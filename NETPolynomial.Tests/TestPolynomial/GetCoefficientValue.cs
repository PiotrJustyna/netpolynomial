using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class GetCoefficientValue : TestBase
    {
        [TestMethod]
        public void GetCoefficientValue_WhenUsingNullICoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                Double result = testedPolynomial.GetCoefficientValue(null);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Coefficient could not be found. Please make sure it was declared. Coefficient name:"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void GetCoefficientValue_WhenUsingIncorrectCoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                Double result = testedPolynomial.GetCoefficientValue("b");
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Coefficient could not be found. Please make sure it was declared. Coefficient name:"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void GetCoefficientValue_WhenUsingCorrectCoefficientName_ShouldReturnCorrectValue()
        {
            // arrange
            Polynomial testedPolynomial = new Polynomial(
                new String[] { "x" }
                , new String[] { "a" });
            Double testedValue = 7.0;

            // act
            testedPolynomial.SetCoefficientValue("a", testedValue);
            Double result = testedPolynomial.GetCoefficientValue("a");

            //assert
            Assert.AreEqual(
                testedValue
                , result
                , String.Format(
                    "Tested value and result are not equal. Tested value: {0}, result: {1}"
                    , testedValue
                    , result));
        }
    }
}
