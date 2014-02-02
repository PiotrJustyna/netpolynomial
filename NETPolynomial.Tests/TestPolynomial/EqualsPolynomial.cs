using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class EqualsPolynomial : TestBase
    {
        [TestMethod]
        public void Equals_WhenComparingToNullObject_ShouldReturnFalse()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Boolean result = firstPolynomial.Equals((Polynomial)null);

            Assert.AreEqual(result, false, "Comparison with a null object cannot return true.");
        }

        [TestMethod]
        public void Equals_WhenComparingToItself_ShouldReturnTrue()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Boolean result = firstPolynomial.Equals(firstPolynomial);

            Assert.AreEqual(result, true, "Comparison with itself cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomial_ShouldReturnTrue()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            Assert.AreEqual(result, true, "Comparison with the same polynomial cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToADifferentPolynomial_ShouldReturnFalse()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructCubicPolynomial();
            Boolean result = firstPolynomial.Equals(secondPolynomial);

            Assert.AreEqual(result, false, "Comparison with a different polynomial cannot return true.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomialWithDifferentCoefficientValues_ShouldReturnFalse()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();

            firstPolynomial.SetCoefficientValue("a", 2.0);
            secondPolynomial.SetCoefficientValue("a", 3.0);

            Boolean result = firstPolynomial.Equals(secondPolynomial);

            Assert.AreEqual(result, false, "Comparison with the same polynomial but with different coefficient values cannot return false.");
        }

        [TestMethod]
        public void Equals_WhenComparingToTheSamePolynomialWithDifferentIndeterminateValues_ShouldReturnFalse()
        {
            Polynomial firstPolynomial = ConstructLinearPolynomial();
            Polynomial secondPolynomial = ConstructLinearPolynomial();

            firstPolynomial.SetIndeterminateValue("x", 2.0);
            secondPolynomial.SetIndeterminateValue("x", 3.0);

            Boolean result = firstPolynomial.Equals(secondPolynomial);

            Assert.AreEqual(result, false, "Comparison with the same polynomial but with different coefficient values cannot return false.");
        }
    }
}
