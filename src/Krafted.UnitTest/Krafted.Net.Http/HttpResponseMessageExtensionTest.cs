using System.Net;
using System.Net.Http;
using System.Text;
using Krafted.Net.Http;
using Xunit;
using Assert = Krafted.Test.XUnit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Net.Http
{
    [Trait(nameof(UnitTest), nameof(Http))]
    public class HttpResponseMessageExtensionTest
    {
        [Fact]
        public void EnsureContentType_DefaultContentType_DoesNotThrowsException()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.UTF8, "application/json") };
            Assert.DoesNotThrows(() => response1.EnsureContentType());

            var response2 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.ASCII, "text/html") };
            Assert.DoesNotThrows(() => response2.EnsureContentType("text/html; charset=us-ascii"));
        }

        [Theory]
        [InlineData("ASCII", "application/json")]
        [InlineData("UTF-8", "text/html")]
        public void EnsureContentType_NotUtf8ApplicationJson_ThrowsException(string encoding, string mediaType)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.GetEncoding(encoding), mediaType) };
            Assert.Throws<HttpRequestException>(() => response.EnsureContentType());
        }
    }
}