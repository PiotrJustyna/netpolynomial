using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace NETPolynomial.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void PrepareTest()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }

        protected Polynomial ConstructConstantPolynomial()
        {
            Polynomial testedPolynomial = new Polynomial(
                null
                , new String[] { "a" });

            testedPolynomial.AddTerm("a", null);

            return testedPolynomial;
        }

        protected Polynomial ConstructLinearPolynomial()
        {
            Polynomial testedPolynomial = new Polynomial(
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

        protected Polynomial ConstructQuadraticPolynomial()
        {
            Polynomial testedPolynomial = new Polynomial(
                new String[] { "x" }
                , new String[] { "a", "b", "c" });

            testedPolynomial.AddTerm(
                "a"
                , new Dictionary<String, Double>() { { "x", 2.0 } });

            testedPolynomial.AddTerm(
                "b"
                , new Dictionary<String, Double>() { { "x", 1.0 } });

            testedPolynomial.AddTerm(
                "c"
                , null);

            return testedPolynomial;
        }

        protected Polynomial ConstructCubicPolynomial()
        {
            Polynomial testedPolynomial = new Polynomial(
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
