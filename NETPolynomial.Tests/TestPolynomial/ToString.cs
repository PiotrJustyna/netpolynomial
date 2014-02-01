using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class ToString : TestBase
    {
        [TestMethod]
        public void ToString_WhenPrintingAConstantPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructConstantPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a");
        }

        [TestMethod]
        public void ToString_WhenPrintingALinearPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructLinearPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^1.00 + b");
        }

        [TestMethod]
        public void ToString_WhenPrintingAQuadraticPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructQuadraticPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^2.00 + b * x^1.00 + c");
        }

        [TestMethod]
        public void ToString_WhenPrintingACubicPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructCubicPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^3.00 + b * x^2.00 + c * x^1.00 + d");
        }
    }
}
