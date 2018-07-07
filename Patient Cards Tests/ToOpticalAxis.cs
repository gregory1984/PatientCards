using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class ToOpticalAxis
    {
        [TestMethod]
        public void ToOpticalAxis_StringNullOrWhitespace()
        {
            string obj = null;
            Assert.AreEqual(null, obj.ToOpticalAxis());

            obj = "";
            Assert.AreEqual(null, obj.ToOpticalAxis());
        }

        [TestMethod]
        public void ToOpticalAxis_StringNumbers()
        {
            string obj = "0";
            Assert.AreEqual(0, obj.ToOpticalAxis());

            obj = "00000";
            Assert.AreEqual(0, obj.ToOpticalAxis());

            obj = "180";
            Assert.AreEqual(180, obj.ToOpticalAxis());

            obj = "-1";
            Assert.AreEqual(0, obj.ToOpticalAxis());

            obj = "181";
            Assert.AreEqual(0, obj.ToOpticalAxis());
        }
    }
}
