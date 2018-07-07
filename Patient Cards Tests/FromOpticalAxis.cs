using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class FromOpticalAxis
    {
        [TestMethod]
        public void FromOpticalAxis_IntNull()
        {
            int? obj = null;
            Assert.AreEqual("", obj.FromOpticalAxis());
        }

        [TestMethod]
        public void FromOpticalAxis_IntZero()
        {
            int? obj = 0;
            Assert.AreEqual("0", obj.FromOpticalAxis());
        }

        [TestMethod]
        public void FromOpticalAxis_IntNumbers()
        {
            int? obj = 180;
            Assert.AreEqual("180", obj.FromOpticalAxis());

            obj = -1;
            Assert.AreEqual("0", obj.FromOpticalAxis());

            obj = 181;
            Assert.AreEqual("0", obj.FromOpticalAxis());
        }
    }
}
