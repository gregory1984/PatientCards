using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patient_Cards.Helpers;

namespace Patient_Cards_Tests
{
    [TestClass]
    public class FromOpticalSharpness
    {
        [TestMethod]
        public void FromOpticalSharpness_IntNull()
        {
            decimal? obj = null;
            Assert.AreEqual("", obj.FromOpticalSharpness());
        }

        [TestMethod]
        public void FromOpticalSharpness_IntZero()
        {
            decimal? obj = 0;
            Assert.AreEqual("0", obj.FromOpticalSharpness());
        }

        [TestMethod]
        public void FromOpticalSharpness_IntNumbers()
        {
            decimal? obj = 1.5m;
            Assert.AreEqual("1,5", obj.FromOpticalSharpness());

            obj = 1.6m;
            Assert.AreEqual("0", obj.FromOpticalSharpness());

            obj = 1m;
            Assert.AreEqual("1", obj.FromOpticalSharpness());
        }
    }
}
