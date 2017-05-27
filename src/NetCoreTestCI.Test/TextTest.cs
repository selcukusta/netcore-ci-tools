using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCoreTestCI.Framework;

namespace NetCoreTestCI.Test
{
    [TestClass]
    public class TextTest
    {
        [TestMethod]
        public void TestSlugify()
        {
            var input = "Hello .Net Core!";
            var expected = "hello-net-core";
            var result = Text.Slugify(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSlugifyWithTurkishChars()
        {
            var input = "Türkçe karakterler çok şanslı!";
            var expected = "turkce-karakterler-cok-sansli";
            var result = Text.Slugify(input);
            Assert.AreEqual(expected, result);
        }
    }
}
