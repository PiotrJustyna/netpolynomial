using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;

namespace NETPolynomial.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void PrepareTests()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        }
    }
}
