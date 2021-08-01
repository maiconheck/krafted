using System;
using Krafted.ValueObjects;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class UrlTest
    {
        [Theory]
        [InlineData("https://www.example.com")]
        [InlineData("http://www.example.com")]
        [InlineData("https://www.example.co")]
        [InlineData("http://www.example.co")]
        [InlineData("www.domain.com")]
        [InlineData("http://www.example.com/resource")]
        [InlineData("http://www.example.com/resource/id/1")]
        [InlineData("http://www.example.com/resource/query?id=3&name=foo")]
        [InlineData("https://www.example.com/resource/file/foo.html")]
        public void NewUrl_ValidUrl_DoesNotThrowsException(string validUrl)
        {
            Assert.DoesNotThrows(() => new Url(validUrl));
            Assert.DoesNotThrows(() => (Url)validUrl);
            Assert.DoesNotThrows(() => Url.NewUrl(validUrl));
        }

        [Theory]
        [InlineData("https://www.example")]
        [InlineData("www.example")]
        [InlineData("https://www.example-.com")]
        [InlineData("https://www.-example.com")]
        [InlineData("example.com")]
        [InlineData("https://www.domain#.com")]
        [InlineData("www.example#.com")]
        public void NewUrl_InvalidUrl_ThrowsException(string invalidUrl)
        {
            var ex1 = Assert.Throws<FormatException>(() => new Url(invalidUrl));
            Assert.Equal($"Invalid URL: {invalidUrl}.", ex1.Message);

            var ex2 = Assert.Throws<FormatException>(() => (Url)invalidUrl);
            Assert.Equal($"Invalid URL: {invalidUrl}.", ex2.Message);

            var ex3 = Assert.Throws<FormatException>(() => Url.NewUrl(invalidUrl));
            Assert.Equal($"Invalid URL: {invalidUrl}.", ex3.Message);
        }

        [Fact]
        public void NewUrl_ToString_StringUrl()
        {
            const string expected = "https://www.domain.com";

            Assert.Equal(expected, new Url(expected).ToString());
            Assert.Equal(expected, ((Url)expected).ToString());
            Assert.Equal(expected, Url.NewUrl(expected).ToString());
        }
    }
}
