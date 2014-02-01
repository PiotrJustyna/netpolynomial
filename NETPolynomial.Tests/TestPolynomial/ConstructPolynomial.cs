using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class ConstructPolynomial : TestBase
    {
        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithoutCoefficientsAndIndeterminates_ShouldThrowAnArgumentException()
        {
            try
            {
                // act
                Polynomial testedPolynomial = new Polynomial(
                    null
                    , null);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("No indeterminates or coefficients provided."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithTooManyIndeterminates_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                StringBuilder indeterminateName = new StringBuilder();
                String[] tooBigArrayOfIndeterminateNames = new String[Consts.MaximumNumberOfIndeterminates + 1];

                for (Int32 i = 0; i < tooBigArrayOfIndeterminateNames.Length; i++)
                {
                    indeterminateName.Append("x");
                    tooBigArrayOfIndeterminateNames[i] = indeterminateName.ToString();
                }

                // act
                Polynomial testedPolynomial = new Polynomial(
                    tooBigArrayOfIndeterminateNames
                    , new String[] { "a" });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains(String.Format("Too many indeterminates, the limit is: {0}.", Consts.MaximumNumberOfIndeterminates)));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithTooManyCoefficients_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                StringBuilder coefficientName = new StringBuilder();
                String[] tooBigArrayOfCoefficientNames = new String[Consts.MaximumNumberOfCoefficients + 1];

                for (Int32 i = 0; i < tooBigArrayOfCoefficientNames.Length; i++)
                {
                    coefficientName.Append("a");
                    tooBigArrayOfCoefficientNames[i] = coefficientName.ToString();
                }

                // act
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , tooBigArrayOfCoefficientNames);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains(String.Format("Too many coefficients, the limit is: {0}.", Consts.MaximumNumberOfIndeterminates)));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithDuplicatedIndeterminateNames_ShouldThrowAnArgumentException()
        {
            try
            {
                // act
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x", "x" }
                    , null);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Provided indeterminate names are incorrect. Please check for duplicates."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithDuplicatedCoefficientNames_ShouldThrowAnArgumentException()
        {
            try
            {
                // act
                Polynomial testedPolynomial = new Polynomial(
                    null
                    , new String[] { "y", "y" });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Provided coefficient names are incorrect. Please check for duplicates."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithClashingIndeterminateAndCoefficientNames_ShouldThrowAnArgumentException()
        {
            try
            {
                // act
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "x" });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Provided coefficient names are incorrect. Please check for duplicates."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }
    }
}
