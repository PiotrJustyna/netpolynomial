using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class Copy : TestBase
    {
        [TestMethod]
        public void Copy_WhenCopyingAPolynomialWithDifferentTerms_CopyShouldBeCreatedCorrectly()
        {
            // arrange
            String indetermindate = "x";
            String firstCoefficient = "a";
            String secondCoefficient = "b";

            Polynomial copiedPolynomial = null;
            Polynomial testedPolynomial = new Polynomial(
                new String[] { indetermindate }
                , new String[] { 
                    firstCoefficient
                    , secondCoefficient });

            testedPolynomial.AddTerm(firstCoefficient);
            testedPolynomial.AddTerm(new Dictionary<String, Double>() { {
                indetermindate
                , 2.0 } });
            testedPolynomial.AddTerm(secondCoefficient, new Dictionary<String, Double>() { { 
                indetermindate
                , 1.0 } });

            // act
            copiedPolynomial = testedPolynomial.Copy();

            // assert
            Assert.IsTrue(testedPolynomial.Equals(copiedPolynomial), "Copied polynomial is diffetent than the tested one.");
            Assert.AreNotEqual(testedPolynomial.GetHashCode(), copiedPolynomial.GetHashCode());

            // arrange
            testedPolynomial.SetIndeterminateValue(indetermindate, 5.0);

            // assert
            Assert.IsFalse(testedPolynomial.Equals(copiedPolynomial), "Copied polynomial is the same as the tested one, expected different results.");
            Assert.AreNotEqual(testedPolynomial.GetHashCode(), copiedPolynomial.GetHashCode());

            // arrange
            testedPolynomial.SetIndeterminateValue(indetermindate, 0.0);
            testedPolynomial.SetCoefficientValue(firstCoefficient, 2.0);

            // assert
            Assert.IsFalse(testedPolynomial.Equals(copiedPolynomial), "Copied polynomial is the same as the tested one, expected different results.");
            Assert.AreNotEqual(testedPolynomial.GetHashCode(), copiedPolynomial.GetHashCode());
        }
    }
}
