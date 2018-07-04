using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class ToOpticalString
    {
        [TestMethod]
        public void ToOpticalString_DecimalNull()
        {
            decimal? obj = null;
            Assert.AreEqual("", obj.ToOpticalString());
        }

        [TestMethod]
        public void ToOpticalString_DecimalZero()
        {
            decimal? obj = 0;
            Assert.AreEqual("", obj.ToOpticalString());
        }

        [TestMethod]
        public void ToOpticalString_DecimalPositiveNumber()
        {
            decimal? obj = 1.45m;
            Assert.AreEqual("+1,45", obj.ToOpticalString());
        }

        [TestMethod]
        public void ToOpticalString_DecimalNegativeNumber()
        {
            decimal? obj = -1.45m;
            Assert.AreEqual("-1,45", obj.ToOpticalString());
        }

        [TestMethod]
        public void ToOpticalString_DecimalPositiveIntegerNumber()
        {
            decimal? obj = 10m;
            Assert.AreEqual("+10", obj.ToOpticalString());
        }

        [TestMethod]
        public void ToOpticalString_DecimalNegativeIntegerNumber()
        {
            decimal? obj = -10m;
            Assert.AreEqual("-10", obj.ToOpticalString());
        }
    }
}
