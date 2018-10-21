using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.Helper.Tests
{
    [TestClass()]
    public class Int32ExTests
    {
        [TestMethod()]
        public void InRangeTest()
        {
            Assert.IsTrue(0.InRange(0, 0));
            Assert.IsTrue(0.InRange(0, 9));
            Assert.IsTrue(9.InRange(0, 9));
            Assert.IsTrue(0.InRange(9, 0));
            Assert.IsTrue(9.InRange(9, 0));
            Assert.IsTrue(0.InRange(-1, 1));
            Assert.IsTrue(0.InRange(1, -1));
            Assert.IsFalse(2.InRange(-1, 1));
            Assert.IsFalse(2.InRange(1, -1));
        }
    }
}