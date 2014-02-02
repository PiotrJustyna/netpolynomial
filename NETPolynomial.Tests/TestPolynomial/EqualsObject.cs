using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class EqualsObject : TestBase
    {
        [TestMethod]
        public void Equals_WhenComparingToNonPolynomialObject_ShouldReturnFalse()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();

            // act
            Boolean result = firstPolynomial.Equals("Hello World!");

            // assert
            Assert.AreEqual(result, false, "Comparison with a non polynomial object cannot return true.");
        }

        [TestMethod]
        public void Equals_WhenComparingToNullObject_ShouldReturnFalse()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();

            // act
            Boolean result = firstPolynomial.Equals((Object)null);

            // assert
            Assert.AreEqual(result, false, "Comparison with a null object cannot return true.");
        }

        [TestMethod]
        public void Equals_WhenComparingToItself_ShouldReturnTrue()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();

            // act
            Boolean result = firstPolynomial.Equals(firstPolynomial);

            // assert
            Assert.AreEqual(result, true, "Comparison with itself cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomial_ShouldReturnTrue()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();

            // act
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            // assert
            Assert.AreEqual(result, true, "Comparison with the same polynomial cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToADifferentPolynomial_ShouldReturnFalse()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructCubicPolynomial();

            // act
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            // assert
            Assert.AreEqual(result, false, "Comparison with a different polynomial cannot return true.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomialWithDifferentCoefficientValues_ShouldReturnFalse()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();

            firstPolynomial.SetCoefficientValue("a", 2.0);
            secondPolynomial.SetCoefficientValue("a", 3.0);

            // act
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            // assert
            Assert.AreEqual(result, false, "Comparison with the same polynomial but with different coefficient values cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomialWithDifferentIndeterminateValues_ShouldReturnFalse()
        {
            // arrange
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();

            firstPolynomial.SetIndeterminateValue("x", 2.0);
            secondPolynomial.SetIndeterminateValue("x", 3.0);

            // act
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            // assert
            Assert.AreEqual(result, false, "Comparison with the same polynomial but with different coefficient values cannot return false.");
        }
    }
}
