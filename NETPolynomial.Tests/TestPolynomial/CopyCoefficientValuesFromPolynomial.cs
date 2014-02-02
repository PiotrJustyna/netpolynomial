using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class CopyCoefficientValuesFromPolynomial : TestBase
    {
        [TestMethod]
        public void CopyCoefficientValues_WhenCopyingFromDifferentTypeOfPolynomial_ShouldThrowAnArgumentException()
        {
            // arrange
            Polynomial sourcePolynomial = ConstructLinearPolynomial();
            Polynomial destinationPolynomial = ConstructQuadraticPolynomial();

            try
            {
                // act
                destinationPolynomial.CopyCoefficientValuesFromPolynomial(sourcePolynomial);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Structures of source destination polynomials are not the same. Please check used terms, coefficients and indeterminates."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void CopyCoefficientValues_WhenCopyingFromTheSameTypeOfPolynomial_ShouldThrowAnArgumentException()
        {
            // arrange
            Polynomial sourcePolynomial = ConstructLinearPolynomial();
            Polynomial destinationPolynomial = ConstructLinearPolynomial();

            sourcePolynomial.SetCoefficientValue("a", 3.0);
            sourcePolynomial.SetCoefficientValue("b", 4.0);

            destinationPolynomial.SetCoefficientValue("a", 5.0);
            destinationPolynomial.SetCoefficientValue("b", 6.0);

            // assert
            Assert.AreEqual(sourcePolynomial.Equals(destinationPolynomial), false, "Source and destination polynomials are supposed to be different.");

            // act
            destinationPolynomial.CopyCoefficientValuesFromPolynomial(sourcePolynomial);

            // assert
            Assert.AreEqual(sourcePolynomial.Equals(destinationPolynomial), true, "Source and destination polynomials are supposed to be the same.");
        }
    }
}
