#region Notes
    // This file shows how to test functions.
#endregion

using CalculatorFinal;

namespace CalculatorFinal
{
    [TestClass]
    public class CalculatorToolsTests
    {
        [TestMethod]
        public void CanCastString2Integer()
        {
            double result = Tools.CastString2Double("123");
            Assert.AreEqual(result, 123);

            result = Tools.CastString2Double("-123");
            Assert.AreEqual(result, -123);

        }
        [TestMethod]
        public void CanCastString2Decimal()
        {
            double result = Tools.CastString2Double("-12.3");
            Assert.AreEqual(result, -12.3);

            result = Tools.CastString2Double(".");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void CanValidStr()
        {
            Assert.IsFalse(Tools.CastStrValidation("12.12.2"));
            Assert.IsTrue(Tools.CastStrValidation("-12213.123"));
        }
    }
}