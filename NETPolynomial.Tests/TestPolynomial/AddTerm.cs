using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NETPolynomial.Tests.TestPolynomial
{
    [TestClass]
    public class AddTerm : TestBase
    {
        [TestMethod]
        public void AddTerm_WhenAddingTooManyTermsWithCoefficients_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                for (Int32 i = 0; i < Consts.MaximumNumberOfTerms; i++)
                {
                    testedPolynomial.AddTerm(
                        "a"
                        , new Dictionary<string, double>() { { "x", 1.0 } });
                }

                // act
                testedPolynomial.AddTerm(
                    "a"
                    , new Dictionary<string, double>() { { "x", 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains(String.Format("Limit of terms is reached, could not add new term. Current limit: {0}", Consts.MaximumNumberOfTerms)));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithInvalidCoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("b");
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
        public void AddTerm_WhenAddingTermWithoutCoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm((String)null);
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
        public void AddTerm_WhenAddingTermWithValidCoefficientNameAndMissingIndeterminate_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("a", new Dictionary<string, double>() { { "y", 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithValidCoefficientNameAndTooLowDegree_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("a", new Dictionary<string, double>() { { "x", Consts.MinimumIndeterminateDegree - 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithValidCoefficientNameAndTooHighDegree_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("a", new Dictionary<string, double>() { { "x", Consts.MaximumIndeterminateDegree + 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTooManyTermsWithoutCoefficients_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , null);

                for (Int32 i = 0; i < Consts.MaximumNumberOfTerms; i++)
                {
                    testedPolynomial.AddTerm(new Dictionary<string, double>() { { "x", 1.0 } });
                }

                // act
                testedPolynomial.AddTerm(new Dictionary<string, double>() { { "x", 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains(String.Format("Limit of terms is reached, could not add new term. Current limit: {0}", Consts.MaximumNumberOfTerms)));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithoutCoefficientNameAndNoIndeterminates_ShouldThrowAnArgumentException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm((Dictionary<String, Double>)null);
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates is empty, which makes the term invalid since the coefficient is not used."));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentException), "Expected \"ArgumentException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithoutCoefficientNameAndMissingIndeterminate_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm(new Dictionary<string, double>() { { "y", 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithoutCoefficientNameAndTooLowDegree_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm(new Dictionary<string, double>() { { "x", Consts.MinimumIndeterminateDegree - 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }

        [TestMethod]
        public void AddTerm_WhenAddingTermWithoutCoefficientNameAndTooHighDegree_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                Polynomial testedPolynomial = new Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm(new Dictionary<string, double>() { { "x", Consts.MaximumIndeterminateDegree + 1.0 } });
            }
            catch (Exception exception)
            {
                // assert
                Assert.IsTrue(exception.Message.Contains("Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of"));
                Assert.AreEqual(exception.GetType(), typeof(ArgumentOutOfRangeException), "Expected \"ArgumentOutOfRangeException\" exception.");

                return;
            }

            // assert
            Assert.Fail("Expected an exception to be thrown.");
        }
    }
}
