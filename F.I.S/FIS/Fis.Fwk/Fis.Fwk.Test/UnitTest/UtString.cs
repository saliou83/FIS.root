using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fis.Fwk.Core.Extension;

namespace Fis.Fwk.Test.UnitTest
{
    [TestClass]
    public class UtString
    {
        [TestMethod]
        public void TestToTitleCase()
        {
            string testString = "machaine";
            Assert.AreNotEqual("machaine", testString.ToTitleCase());
            Assert.AreEqual("Machaine", testString.ToTitleCase());
        }
    }
}
