﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class SetIndeterminateValue : TestBase
    {
        [TestMethod]
        public void SetIndeterminateValue_WhenUsingNullIndeterminateName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.SetIndeterminateValue(null, 1.0);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Indeterminate could not be found. Please make sure it was declared. Indeterminate name:"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void SetIndeterminateValue_WhenUsingIncorrectIndeterminateName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.SetIndeterminateValue("y", 1.0);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Indeterminate could not be found. Please make sure it was declared. Indeterminate name:"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void SetIndeterminateValue_WhenUsingCorrectIndeterminateName_ShouldSetTheValueCorrectly()
        {
            // arrange
            Polynomial testedPolynomial = new Polynomial(
                new String[] { "x" }
                , new String[] { "a" });
            Double testedIndeterminateValue = 4.0;

            // act
            testedPolynomial.SetIndeterminateValue("x", testedIndeterminateValue);
            Double result = testedPolynomial.GetIndeterminateValue("x");

            // assert
            Assert.AreEqual(
                testedIndeterminateValue
                , result
                , String.Format(
                    "Tested value and result are not equal. Tested value: {0}, result: {1}"
                    , testedIndeterminateValue
                    , result));
        }
    }
}
