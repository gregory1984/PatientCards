using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class ToOpticalNumber
    {
        [TestMethod]
        public void ToOpticalNumber_StringNullOrWhitespace()
        {
            string obj = null;
            Assert.AreEqual(null, obj.ToOpticalNumber());

            obj = "";
            Assert.AreEqual(null, obj.ToOpticalNumber());
        }

        [TestMethod]
        public void ToOpticalNumber_StringZero()
        {
            string obj = "0";
            Assert.AreEqual(0, obj.ToOpticalNumber());

            obj = "-0";
            Assert.AreEqual(0, obj.ToOpticalNumber());

            obj = "0,0";
            Assert.AreEqual(0, obj.ToOpticalNumber());

            obj = "-0,0";
            Assert.AreEqual(0, obj.ToOpticalNumber());
        }

        [TestMethod]
        public void ToOpticalNumber_StringPositiveNumber()
        {
            string obj = "+1,45";
            Assert.AreEqual(1.45m, obj.ToOpticalNumber());
        }

        [TestMethod]
        public void ToOpticalNumber_StringNegativeNumber()
        {
            string obj = "-1,45";
            Assert.AreEqual(-1.45m, obj.ToOpticalNumber());
        }

        [TestMethod]
        public void ToOpticalNumber_StringPositiveIntegerNumber()
        {
            string obj = "+10";
            Assert.AreEqual(10m, obj.ToOpticalNumber());
        }

        [TestMethod]
        public void ToOpticalNumber_StringNegativeIntegerNumber()
        {
            string obj = "-10";
            Assert.AreEqual(-10, obj.ToOpticalNumber());
        }
    }
}
