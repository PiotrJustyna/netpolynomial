using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class GetValue : TestBase
    {
        [TestMethod]
        public void GetValue_WhenGettingValueOfAConstantPolynomial_ValueIsCalculatedCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructConstantPolynomial();

            testedPolynomial.SetCoefficientValue("a", 5.0);

            // act
            Double value = testedPolynomial.GetValue();

            // assert
            Assert.AreEqual(value, 5.0);
        }

        [TestMethod]
        public void GetValue_WhenGettingValueOfALinearPolynomial_ValueIsCalculatedCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructLinearPolynomial();

            testedPolynomial.SetCoefficientValue("a", 1.0);
            testedPolynomial.SetCoefficientValue("b", 2.0);

            testedPolynomial.SetIndeterminateValue("x", 1.0);

            // act
            Double value = testedPolynomial.GetValue();

            // assert
            Assert.AreEqual(value, 3.0);
        }

        [TestMethod]
        public void GetValue_WhenGettingValueOfAQuadraticPolynomial_ValueIsCalculatedCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructQuadraticPolynomial();

            testedPolynomial.SetCoefficientValue("a", 1.0);
            testedPolynomial.SetCoefficientValue("b", 2.0);
            testedPolynomial.SetCoefficientValue("c", 3.0);

            testedPolynomial.SetIndeterminateValue("x", 2.0);

            // act
            Double value = testedPolynomial.GetValue();

            // assert
            Assert.AreEqual(value, 11.0);
        }

        [TestMethod]
        public void GetValue_WhenGettingValueOfACubicPolynomial_ValueIsCalculatedCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = ConstructCubicPolynomial();

            testedPolynomial.SetCoefficientValue("a", 1.0);
            testedPolynomial.SetCoefficientValue("b", 2.0);
            testedPolynomial.SetCoefficientValue("c", 3.0);
            testedPolynomial.SetCoefficientValue("d", 4.0);

            testedPolynomial.SetIndeterminateValue("x", 3.0);

            // act
            Double value = testedPolynomial.GetValue();

            // assert
            Assert.AreEqual(value, 58.0);
        }
    }
}
