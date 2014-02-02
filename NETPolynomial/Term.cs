using System;
using System.Collections.Generic;
using System.Linq;

namespace NETPolynomial
{
    /// <summary>
    /// Represents the polynomial's term.
    /// </summary>
    internal sealed class Term
    {
        /// <summary>
        /// Constructor accepting term's coefficient name and a collection of indeterminates with their degrees.
        /// </summary>
        /// <param name="coefficientName">Name of the term's coefficient.</param>
        /// <param name="indeterminatesWithDegrees">Collection of indeterminates names with their degrees.</param>
        internal Term(
            String coefficientName
            , Dictionary<String, Double> indeterminatesWithDegrees)
        {
            CoefficientName = coefficientName;
            IndeterminatesWithDegrees = indeterminatesWithDegrees;
        }

        /// <summary>
        /// Constructor accepting a collection of indeterminates with their degrees.
        /// </summary>
        /// <param name="indeterminatesWithDegrees">Collection of indeterminates names with their degrees.</param>
        internal Term(Dictionary<String, Double> indeterminatesWithDegrees)
            : this(
                null
                , indeterminatesWithDegrees) { }

        /// <summary>
        /// Constructor accepting only a coefficient name. Used for constant terms.
        /// </summary>
        /// <param name="coefficientName">Name of the term's coefficient.</param>
        internal Term(String coefficientName)
            : this(
                coefficientName
                , null) { }

        internal String CoefficientName { get; private set; }

        internal Dictionary<String, Double> IndeterminatesWithDegrees { get; private set; }

        internal Double Degree
        {
            get
            {
                Double degree = 0.0;

                if(IndeterminatesWithDegrees != null)
                {
                    degree = IndeterminatesWithDegrees.Values.Sum(singleDegree => singleDegree);
                }

                return degree;
            }
        }
    }
}
