using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NETPolynomial.Tests
{
    [TestClass]
    public class Polynomial : TestBase
    {
        [TestMethod]
        public void ConstructPolynomial_WhenConstructingPolynomialWithoutCoefficientsAndIndeterminates_ShouldThrowAnArgumentException()
        {
            try 
	        {
                // act
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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

        [TestMethod]
        public void SetIndeterminateValue_WhenUsingNullIndeterminateName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
        public void SetCoefficientValue_WhenUsingNullICoefficientName_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
        public void AddTerm_WhenAddingTooManyTermsWithCoefficients_ShouldThrowAnArgumentOutOfRangeException()
        {
            try
            {
                // arrange
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("b", null);
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm("a", new Dictionary<string,double>() { { "y", 1.0 } });
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                    new String[] { "x" }
                    , new String[] { "a" });

                // act
                testedPolynomial.AddTerm(null);
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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
                NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
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

        [TestMethod]
        public void ToString_WhenPrintingAConstantPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            NETPolynomial.Polynomial testedPolynomial = ConstructConstantPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a");
        }

        [TestMethod]
        public void ToString_WhenPrintingALinearPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            NETPolynomial.Polynomial testedPolynomial = ConstructLinearPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^1.00 + b");
        }

        [TestMethod]
        public void ToString_WhenPrintingAQuadraticPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            NETPolynomial.Polynomial testedPolynomial = ConstructQuadraticPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^2.00 + b * x^1.00 + c");
        }

        [TestMethod]
        public void ToString_WhenPrintingACubicPolynomial_ShouldPrintCorrectly()
        {
            // arrange
            NETPolynomial.Polynomial testedPolynomial = ConstructCubicPolynomial();

            // act
            String printedValue = testedPolynomial.ToString();

            // assert
            Assert.AreEqual(printedValue, "a * x^3.00 + b * x^2.00 + c * x^1.00 + d");
        }

        [TestMethod]
        public void GetValue_WhenGettingValueOfAConstantPolynomial_ValueIsCalculatedCorrectly()
        {
            // arrange
            NETPolynomial.Polynomial testedPolynomial = ConstructConstantPolynomial();

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
            NETPolynomial.Polynomial testedPolynomial = ConstructLinearPolynomial();

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
            NETPolynomial.Polynomial testedPolynomial = ConstructQuadraticPolynomial();

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
            NETPolynomial.Polynomial testedPolynomial = ConstructCubicPolynomial();

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

        private NETPolynomial.Polynomial ConstructConstantPolynomial()
        {
            NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                null
                , new String[] { "a" });

            testedPolynomial.AddTerm("a", null);

            return testedPolynomial;
        }

        private NETPolynomial.Polynomial ConstructLinearPolynomial()
        {
            NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                new String[] { "x" }
                , new String[] { "a", "b" });

            testedPolynomial.AddTerm(
                "a"
                , new Dictionary<string, double>() { { "x", 1.0 } });

            testedPolynomial.AddTerm(
                "b"
                , null);

            return testedPolynomial;
        }

        private NETPolynomial.Polynomial ConstructQuadraticPolynomial()
        {
            NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                new String[] { "x" }
                , new String[] { "a", "b", "c" });

            testedPolynomial.AddTerm(
                "a"
                , new Dictionary<string, double>() { { "x", 2.0 } });

            testedPolynomial.AddTerm(
                "b"
                , new Dictionary<string, double>() { { "x", 1.0 } });

            testedPolynomial.AddTerm(
                "c"
                , null);

            return testedPolynomial;
        }

        private NETPolynomial.Polynomial ConstructCubicPolynomial()
        {
            NETPolynomial.Polynomial testedPolynomial = new NETPolynomial.Polynomial(
                new String[] { "x" }
                , new String[] { "a", "b", "c", "d" });

            testedPolynomial.AddTerm(
                "a"
                , new Dictionary<string, double>() { { "x", 3.0 } });

            testedPolynomial.AddTerm(
                "b"
                , new Dictionary<string, double>() { { "x", 2.0 } });

            testedPolynomial.AddTerm(
                "c"
                , new Dictionary<string, double>() { { "x", 1.0 } });

            testedPolynomial.AddTerm(
                "d"
                , null);

            return testedPolynomial;
        }
    }
}
