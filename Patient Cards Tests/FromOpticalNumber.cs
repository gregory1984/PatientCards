using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class FromOpticalNumber
    {
        [TestMethod]
        public void FromOpticalNumber_DecimalNull()
        {
            decimal? obj = null;
            Assert.AreEqual("", obj.FromOpticalNumber());
        }

        [TestMethod]
        public void FromOpticalNumber_DecimalZero()
        {
            decimal? obj = 0;
            Assert.AreEqual("0", obj.FromOpticalNumber());
        }

        [TestMethod]
        public void FromOpticalNumber_DecimalPositiveNumber()
        {
            decimal? obj = 1.45m;
            Assert.AreEqual("+1,45", obj.FromOpticalNumber());
        }

        [TestMethod]
        public void FromOpticalNumber_DecimalNegativeNumber()
        {
            decimal? obj = -1.45m;
            Assert.AreEqual("-1,45", obj.FromOpticalNumber());
        }

        [TestMethod]
        public void FromOpticalNumber_DecimalPositiveIntegerNumber()
        {
            decimal? obj = 10m;
            Assert.AreEqual("+10", obj.FromOpticalNumber());
        }

        [TestMethod]
        public void FromOpticalNumber_DecimalNegativeIntegerNumber()
        {
            decimal? obj = -10m;
            Assert.AreEqual("-10", obj.FromOpticalNumber());
        }
    }
}
