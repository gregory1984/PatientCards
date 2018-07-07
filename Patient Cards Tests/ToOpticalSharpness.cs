using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class ToOpticalSharpness
    {
        [TestMethod]
        public void ToOpticalSharpness_StringNullOrWhitespace()
        {
            string obj = null;
            Assert.AreEqual(null, obj.ToOpticalSharpness());

            obj = "";
            Assert.AreEqual(null, obj.ToOpticalSharpness());
        }

        [TestMethod]
        public void ToOpticalSharpness_StringNumbers()
        {
            string obj = "0";
            Assert.AreEqual(0, obj.ToOpticalSharpness());

            obj = "00000";
            Assert.AreEqual(0, obj.ToOpticalSharpness());

            obj = "0,05";
            Assert.AreEqual(0.05m, obj.ToOpticalSharpness());

            obj = "1,5";
            Assert.AreEqual(1.5m, obj.ToOpticalSharpness());

            obj = "1,6";
            Assert.AreEqual(0, obj.ToOpticalSharpness());
        }
    }
}
