using NetCoreTestCI.Framework;
using Xunit;

namespace NetCoreTestCI.Test
{
    public class TextTest
    {
        [Theory]
        [InlineData("Hello .Net Core!", "hello-net-core")]
        [InlineData("Türkçe karakterler çok şanssız!", "turkce-karakterler-cok-sanssiz")]
        public void TestSlugify(string actual, string expected)
        {
            var result = Text.Slugify(actual);
            Assert.Equal<string>(expected, result);
        }
    }
}
