using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class SetCoefficientValue : TestBase
    {
        [TestMethod]
        public void SetCoefficientValue_WhenUsingNullICoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.SetCoefficientValue(null, 1.0);
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
        public void SetCoefficientValue_WhenUsingIncorrectCoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.SetCoefficientValue("b", 1.0);
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
        public void SetCoefficientValue_WhenUsingCorrectCoefficientName_ShouldSetTheValueCorrectly()
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
