using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NETPolynomial
{
    /// <summary>
    /// Represents the polynomial.
    /// </summary>
    public class Polynomial
    {
        private readonly Dictionary<String, Double> _indeterminates = null;
        private readonly Dictionary<String, Double> _coefficients = null;
        private readonly List<Term> _terms = null;

        /// <summary>
        /// Constructor accepting names of used indeterminates and coefficients.
        /// Default indeterminate value is 0.0.
        /// Default coefficient value is 1.0.
        /// </summary>
        /// <param name="indeterminateNames">Names of polynomial's indeterminates.</param>
        /// <param name="coefficientNames">Names of polynomial's coefficients.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// - no indeterminates or coefficients provided
        /// - indetereminate names are incorrect
        /// - coefficient names are incorrect
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - too many indeterminates provided
        /// - too many coefficients provided
        /// </exception>
        public Polynomial(
            String[] indeterminateNames
            , String[] coefficientNames)
        {
            if (CheckIfStringArrayIsEmpty(indeterminateNames)
                && CheckIfStringArrayIsEmpty(coefficientNames))
            {
                throw new ArgumentException("No indeterminates or coefficients provided.");
            }
            else
            {
                // At least one array is not empty which makes the declaration potentially valid 
                // (other validations to follow)
            }

            if (CheckIfStringArrayIsEmpty(indeterminateNames))
            {
                _indeterminates = new Dictionary<String, Double>();
            }
            else if (indeterminateNames.Length > Consts.MaximumNumberOfIndeterminates)
            {
                throw new ArgumentOutOfRangeException(String.Format("Too many indeterminates, the limit is: {0}.", Consts.MaximumNumberOfIndeterminates));
            }
            else if (CheckIfIndeterminateNamesAreCorrect(indeterminateNames))
            {
                _indeterminates = indeterminateNames.ToDictionary<String, String, Double>(singleName => singleName, singleName => 0.0);
            }
            else
            {
                throw new ArgumentException("Provided indeterminate names are incorrect. Please check for duplicates.");
            }

            if (CheckIfStringArrayIsEmpty(coefficientNames))
            {
                _coefficients = new Dictionary<String, Double>();
            }
            else if (coefficientNames.Length > Consts.MaximumNumberOfCoefficients)
            {
                throw new ArgumentOutOfRangeException(String.Format("Too many coefficients, the limit is: {0}.", Consts.MaximumNumberOfCoefficients));
            }
            else if (CheckIfCoefficientNamesAreCorrect(coefficientNames))
            {
                _coefficients = coefficientNames.ToDictionary<String, String, Double>(singleName => singleName, singleName => 1.0);
            }
            else
            {
                throw new ArgumentException("Provided coefficient names are incorrect. Please check for duplicates.");
            }

            _terms = new List<Term>();
        }

        /// <summary>
        /// Sets the value of the indeterminate identified by "indeterminateName" key.
        /// </summary>
        /// <param name="indeterminateName">Name of the indeterminate which value is to be set.</param>
        /// <param name="value">New value of the indeterminate.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no indeterminates declared using "indeterminateName" key
        /// </exception>
        public void SetIndeterminateValue(
            String indeterminateName
            , Double value)
        {
            if (CheckIfIndeterminateIsDeclared(indeterminateName))
            {
                _indeterminates[indeterminateName] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "Indeterminate could not be found. Please make sure it was declared. Indeterminate name: \"{0}\"."
                    , indeterminateName));
            }
        }

        /// <summary>
        /// Gets the value of the indeterminate identified by "indeterminateName" key.
        /// </summary>
        /// <param name="indeterminateName">Name of the indeterminate which value is to be returned.</param>
        /// <returns>
        /// Value of specified indeterminate.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no indeterminates declared using "indeterminateName" key
        /// </exception>
        public Double GetIndeterminateValue(
            String indeterminateName)
        {
            Double result = 0.0;

            if (CheckIfIndeterminateIsDeclared(indeterminateName))
            {
                result = _indeterminates[indeterminateName];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "Indeterminate could not be found. Please make sure it was declared. Indeterminate name: \"{0}\"."
                    , indeterminateName));
            }

            return result;
        }

        /// <summary>
        /// Sets the value of the coefficient identified by "coefficientName" key.
        /// </summary>
        /// <param name="coefficientName">Name of the coefficient which value is to be set.</param>
        /// <param name="value">New value of the coefficient.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no coefficients declared using "coefficientName" key
        /// </exception>
        public void SetCoefficientValue(
            String coefficientName
            , Double value)
        {
            if (CheckIfCoefficientIsDeclared(coefficientName))
            {
                _coefficients[coefficientName] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "Coefficient could not be found. Please make sure it was declared. Coefficient name: \"{0}\"."
                    , coefficientName));
            }
        }

        /// <summary>
        /// Gets the value of the coefficient identified by "coefficientName" key.
        /// </summary>
        /// <param name="coefficientName">Name of the coefficient which value is to be returned.</param>
        /// <returns>
        /// Value of specified coefficient.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no coefficients declared using "coefficientName" key
        /// </exception>
        public Double GetCoefficientValue(
            String coefficientName)
        {
            Double result = 0.0;

            if (CheckIfCoefficientIsDeclared(coefficientName))
            {
                result = _coefficients[coefficientName];
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format(
                    "Coefficient could not be found. Please make sure it was declared. Coefficient name: \"{0}\"."
                    , coefficientName));
            }

            return result;
        }

        /// <summary>
        /// Adds a term with a coefficient to the polynomial.
        /// </summary>
        /// <param name="coefficientName">Coefficient to be included in the term.</param>
        /// <param name="indeterminatesWithDegrees">Collection of indeterminates and their degrees to be included in the term.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - coefficient not provided
        /// - no indeterminates provided
        /// - no coefficients declared using "coefficientName" key
        /// - no indeterminates declared using one of "indeterminatesWithDegrees" keys
        /// - indeterminate degrees not in range
        /// - limit of terms reached
        /// </exception>
        public void AddTerm(
            String coefficientName
            , Dictionary<String, Double> indeterminatesWithDegrees)
        {
            if (_terms.Count < Consts.MaximumNumberOfTerms)
            {
                if (CheckIfCoefficientIsDeclared(coefficientName))
                {
                    if (CheckIfCollectionOfIndeterminatesIsEmpty(indeterminatesWithDegrees))
                    {
                        throw new ArgumentOutOfRangeException("No indeterminates provided.");
                    }
                    else
                    {
                        if (CheckIfCollectionOfIndeterminatesIsCorrect(indeterminatesWithDegrees))
                        {
                            _terms.Add(new Term(coefficientName, CopyProvidedIndeterminates(indeterminatesWithDegrees)));
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(
                                String.Format(
                                "Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of {0:F2} : {1:F2}."
                                , Consts.MinimumIndeterminateDegree
                                , Consts.MaximumIndeterminateDegree));
                        }
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(String.Format(
                        "Coefficient could not be found. Please make sure it was declared. Coefficient name: \"{0}\"."
                        , coefficientName));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Limit of terms is reached, could not add new term. Current limit: {0}", Consts.MaximumNumberOfTerms));
            }
        }

        /// <summary>
        /// Adds a constant term to the polynomial.
        /// </summary>
        /// <param name="coefficientName">Name of the coefficient to form the term.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no coefficients declared using "coefficientName" key
        /// - limit of terms reached
        /// </exception>
        public void AddTerm(String coefficientName)
        {
            if (_terms.Count < Consts.MaximumNumberOfTerms)
            {
                if (CheckIfCoefficientIsDeclared(coefficientName))
                {
                    _terms.Add(new Term(coefficientName));
                }
                else
                {
                    throw new ArgumentOutOfRangeException(String.Format(
                        "Coefficient could not be found. Please make sure it was declared. Coefficient name: \"{0}\"."
                        , coefficientName));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Limit of terms is reached, could not add new term. Current limit: {0}", Consts.MaximumNumberOfTerms));
            }
        }

        /// <summary>
        /// Adds a term without a coefficient to the polynomial.
        /// </summary>
        /// <param name="indeterminatesWithDegrees">Collection of indeterminates and their degrees to be included in the term.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// - collection of indeterminates and their degrees is empty
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when:
        /// - no indeterminates declared using one of "indeterminatesWithDegrees" keys
        /// - indeterminate degrees not in range
        /// - limit of terms reached
        /// </exception>
        public void AddTerm(Dictionary<String, Double> indeterminatesWithDegrees)
        {
            if (_terms.Count < Consts.MaximumNumberOfTerms)
            {
                if (CheckIfCollectionOfIndeterminatesIsEmpty(indeterminatesWithDegrees))
                {
                    throw new ArgumentException(
                        "Collection of indeterminates is empty, which makes the term invalid since the coefficient is not used.");
                }
                else
                {
                    if (CheckIfCollectionOfIndeterminatesIsCorrect(indeterminatesWithDegrees))
                    {
                        _terms.Add(new Term(CopyProvidedIndeterminates(indeterminatesWithDegrees)));
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(
                            String.Format(
                            "Collection of indeterminates and their degrees is not correct. Please make sure all indeterminates were declared and their degrees are in range of {0:F2} : {1:F2}."
                            , Consts.MinimumIndeterminateDegree
                            , Consts.MaximumIndeterminateDegree));
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(String.Format("Limit of terms is reached, could not add new term. Current limit: {0}", Consts.MaximumNumberOfTerms));
            }
        }

        /// <summary>
        /// Calculates current polynomial's value.
        /// </summary>
        /// <returns>Current polynomial's value.</returns>
        public Double GetValue()
        {
            Double result = 0.0;
            Double termValue = 0.0;

            foreach (Term inspectedTerm in _terms)
            {
                termValue = 1.0;

                if (inspectedTerm.IndeterminatesWithDegrees.Count == 0)
                {
                    termValue = _coefficients[inspectedTerm.CoefficientName];
                }
                else
                {
                    foreach (KeyValuePair<String, Double> singleIndeterminateWithDegree in inspectedTerm.IndeterminatesWithDegrees)
                    {
                        termValue *= Math.Pow(
                            _indeterminates[singleIndeterminateWithDegree.Key]
                            , singleIndeterminateWithDegree.Value);
                    }

                    termValue *= _coefficients[inspectedTerm.CoefficientName];
                }

                result += termValue;
            }

            return result;
        }

        /// <summary>
        /// Creates a deep copy of the polynomial.
        /// </summary>
        /// <returns>
        /// Deep copy of the polynomial.
        /// </returns>
        public Polynomial Copy()
        {
            Polynomial deepCopy = new Polynomial(
                _indeterminates.Select(singleIndeterminate => singleIndeterminate.Key).ToArray()
                , _coefficients.Select(singleCoefficient => singleCoefficient.Key).ToArray());

            // Copying the structure of the polynomial.
            foreach (Term singleTerm in _terms)
            {
                if (singleTerm.CoefficientName == null)
                {
                    deepCopy.AddTerm(CopyProvidedIndeterminates(singleTerm.IndeterminatesWithDegrees));
                }
                else if(CheckIfCollectionOfIndeterminatesIsEmpty(singleTerm.IndeterminatesWithDegrees))
                {
                    deepCopy.AddTerm(singleTerm.CoefficientName);
                }
                else
                {
                    deepCopy.AddTerm(
                        singleTerm.CoefficientName
                        , CopyProvidedIndeterminates(singleTerm.IndeterminatesWithDegrees));
                }
            }

            // Copying the values of indeterminates.
            foreach (KeyValuePair<String, Double> singleIndeterminate in _indeterminates)
            {
                deepCopy.SetIndeterminateValue(singleIndeterminate.Key, singleIndeterminate.Value);
            }

            // Copying the values of coefficients.
            foreach (KeyValuePair<String, Double> singleCoefficient in _coefficients)
            {
                deepCopy.SetCoefficientValue(singleCoefficient.Key, singleCoefficient.Value);
            }

            return deepCopy;
        }

        /// <summary>
        /// Copies the values of source polynomial's coefficients to the current polynomial provided that the structures (terms, coefficients and indeterminates) of both polynomials are the same.
        /// </summary>
        /// <param name="sourcePolynomial">
        /// Polynomial to copy the coefficients from.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// - structures of source and destination polynomials are not the same
        /// </exception>
        public void CopyCoefficientValuesFromPolynomial(Polynomial sourcePolynomial)
        {
            if (CheckIfPolynomialStructuresAreTheSame(sourcePolynomial))
            {
                foreach (KeyValuePair<String, Double> singleCoefficient in sourcePolynomial._coefficients)
                {
                    this.SetCoefficientValue(singleCoefficient.Key, singleCoefficient.Value);
                }
            }
            else
            {
                throw new ArgumentException(
                    String.Format(
                        "Structures of source destination polynomials are not the same. Please check used terms, coefficients and indeterminates. Source polynomial: {0}, Destination polynomial: {1}."
                        , sourcePolynomial.ToString()
                        , this.ToString()));
            }
        }

        /// <summary>
        /// Prints the polynomial.
        /// </summary>
        /// <returns>String representation of the polynomial.</returns>
        public override String ToString()
        {
            StringBuilder polynomialBuilder = new StringBuilder();
            IOrderedEnumerable<Term> sortedTerms = _terms.OrderByDescending(singleTerm => singleTerm.Degree);

            foreach (Term inspectedTerm in sortedTerms)
            {
                if (inspectedTerm == sortedTerms.First())
                {
                    polynomialBuilder.AppendFormat("{0} ", inspectedTerm.CoefficientName);
                }
                else
                {
                    polynomialBuilder.AppendFormat("+ {0} ", inspectedTerm.CoefficientName);
                }

                if (inspectedTerm.IndeterminatesWithDegrees != null)
                {
                    IOrderedEnumerable<KeyValuePair<String, Double>> sortedIndeterminates = inspectedTerm
                        .IndeterminatesWithDegrees
                        .OrderByDescending(singleIndeterminateWithDegree => singleIndeterminateWithDegree.Value);

                    foreach (KeyValuePair<String, Double> inspectedIndeterminate in sortedIndeterminates)
                    {
                        if (inspectedTerm.CoefficientName == null)
                        {
                            polynomialBuilder.AppendFormat(
                                "{0}^{1:F2} "
                                , inspectedIndeterminate.Key
                                , inspectedIndeterminate.Value);
                        }
                        else
                        {
                            polynomialBuilder.AppendFormat(
                                "* {0}^{1:F2} "
                                , inspectedIndeterminate.Key
                                , inspectedIndeterminate.Value);
                        }
                    }
                }
            }

            polynomialBuilder.Remove(polynomialBuilder.Length - 1, 1);  // Last space.

            return polynomialBuilder.ToString();
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="obj">Polynomial object to be compared.</param>
        /// <returns>
        /// True - polynomials are identical.
        /// False - polynomials are different.
        /// </returns>
        public override Boolean Equals(Object obj)
        {
            Boolean result = false;

            if (obj != null
                && obj is Polynomial)
            {
                result = this.Equals(obj as Polynomial);
            }

            return result;
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="polynomialObject">Polynomial object to be compared.</param>
        /// <returns>
        /// True - polynomials are identical.
        /// False - polynomials are different.
        /// </returns>
        public Boolean Equals(Polynomial polynomialObject)
        {
            return
                CheckIfPolynomialStructuresAreTheSame(polynomialObject)
                && CheckIfCoefficientValuesAreEqual(polynomialObject)
                && CheckIfIndeterminateValuesAreEqual(polynomialObject);
        }

        /// <summary>
        /// Gets object's hash code.
        /// </summary>
        /// <returns>
        /// Object's hash code.
        /// </returns>
        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns names of all polynomial's coefficients.
        /// </summary>
        /// <returns>
        /// Names of all polynomial's coefficients.
        /// </returns>
        public String[] GetAllCoefficientNames()
        {
            return _coefficients.Keys.ToArray();
        }

        /// <summary>
        /// Returns names of all polynomial's indeterminates.
        /// </summary>
        /// <returns>
        /// Names of all polynomial's indeterminates.
        /// </returns>
        public String[] GetAllIndeterminateNames()
        {
            return _indeterminates.Keys.ToArray();
        }

        private Dictionary<String, Double> CopyProvidedIndeterminates(Dictionary<String, Double> indeterminatesWithDegrees)
        {
            Dictionary<String, Double> copy = new Dictionary<String, Double>();

            foreach (KeyValuePair<String, Double> singleIndeterminateWithDegree in indeterminatesWithDegrees)
            {
                copy.Add(singleIndeterminateWithDegree.Key, singleIndeterminateWithDegree.Value);
            }

            return copy;
        }

        private Boolean CheckIfPolynomialStructuresAreTheSame(Polynomial polynomialObject)
        {
            Boolean structureComparisonResult = true;

            if (polynomialObject == null)
            {
                structureComparisonResult = false;
            }
            else
            {
                structureComparisonResult = this.ToString() == polynomialObject.ToString();
            }

            return structureComparisonResult;
        }

        private Boolean CheckIfCoefficientValuesAreEqual(Polynomial polynomialObject)
        {
            Boolean coefficientsComparisonResult = true;

            if (polynomialObject == null
                || polynomialObject._coefficients == null)
            {
                coefficientsComparisonResult = false;
            }
            else
            {
                foreach (KeyValuePair<String, Double> singleCoefficient in polynomialObject._coefficients)
                {
                    coefficientsComparisonResult &= _coefficients[singleCoefficient.Key] == polynomialObject._coefficients[singleCoefficient.Key];

                    if (coefficientsComparisonResult)
                    {
                        // continute to check next coefficient
                    }
                    else
                    {
                        // values of coefficients are different
                        break;
                    }
                }
            }

            return coefficientsComparisonResult;
        }

        private Boolean CheckIfIndeterminateValuesAreEqual(Polynomial polynomialObject)
        {
            Boolean indeterminateComparisonResult = true;

            if (polynomialObject == null
                || polynomialObject._indeterminates == null)
            {
                indeterminateComparisonResult = false;
            }
            else
            {
                foreach (KeyValuePair<String, Double> singleIndeterminate in polynomialObject._indeterminates)
                {
                    indeterminateComparisonResult &= _indeterminates[singleIndeterminate.Key] == polynomialObject._indeterminates[singleIndeterminate.Key];

                    if (indeterminateComparisonResult)
                    {
                        // continute to check next coefficient
                    }
                    else
                    {
                        // values of coefficients are different
                        break;
                    }
                }
            }

            return indeterminateComparisonResult;
        }

        private Boolean CheckIfStringArrayIsEmpty(String[] strings)
        {
            return strings == null
                || strings.Length == 0;
        }

        private Boolean CheckIfCollectionOfIndeterminatesIsEmpty(Dictionary<String, Double> indeterminatesWithDegrees)
        {
            return indeterminatesWithDegrees == null
                || indeterminatesWithDegrees.Count == 0;
        }

        private Boolean CheckIfIndeterminateNamesAreCorrect(String[] indeterminateNames)
        {
            Boolean namesAreCorrect = true;

            if (_coefficients != null)
            {
                namesAreCorrect = !indeterminateNames
                    .Any(singleIndeterminateName => _coefficients.Keys
                        .Any(singleCoefficientName => singleCoefficientName == singleIndeterminateName));
            }
            else
            {
                // Collection of coefficients is empty,
                // so there will definitely be no name clash between indeterminates and coefficients
            }

            namesAreCorrect &= indeterminateNames.Distinct().Count() == indeterminateNames.Count();

            return namesAreCorrect;
        }

        private Boolean CheckIfCoefficientNamesAreCorrect(String[] coefficientNames)
        {
            Boolean namesAreCorrect = true;

            if (_indeterminates != null)
            {
                namesAreCorrect = !coefficientNames
                    .Any(singleCoefficientName => _indeterminates.Keys
                        .Any(singleIndeterminateName => singleCoefficientName == singleIndeterminateName));
            }
            else
            {
                // Collection of indeterminates is empty,
                // so there will definitely be no name clash between indeterminates and coefficients
            }

            namesAreCorrect &= coefficientNames.Distinct().Count() == coefficientNames.Count();

            return namesAreCorrect;
        }

        private Boolean CheckIfCoefficientIsDeclared(String coefficientName)
        {
            Boolean isCoefficientDeclared = false;

            if (coefficientName == null
                || !_coefficients.ContainsKey(coefficientName))
            {
                isCoefficientDeclared = false;
            }
            else
            {
                isCoefficientDeclared = true;
            }

            return isCoefficientDeclared;
        }

        private Boolean CheckIfIndeterminateIsDeclared(String indeterminateName)
        {
            Boolean isIndeterminateDeclared = false;

            if (indeterminateName == null
                || !_indeterminates.ContainsKey(indeterminateName))
            {
                isIndeterminateDeclared = false;
            }
            else
            {
                isIndeterminateDeclared = true;
            }

            return isIndeterminateDeclared;
        }

        private Boolean CheckIfCollectionOfIndeterminatesIsCorrect(Dictionary<String, Double> indeterminatesWithDegrees)
        {
            Boolean result = false;

            if (indeterminatesWithDegrees == null
                || indeterminatesWithDegrees.Count == 0)
            {
                result = true;
            }
            else
            {
                foreach (KeyValuePair<String, Double> singleIndeterminateWithDegree in indeterminatesWithDegrees)
                {
                    if (CheckIfIndeterminateIsDeclared(singleIndeterminateWithDegree.Key))
                    {
                        if (singleIndeterminateWithDegree.Value >= Consts.MinimumIndeterminateDegree
                            && singleIndeterminateWithDegree.Value <= Consts.MaximumIndeterminateDegree)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
