using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
    public sealed class HttpResponseMessageExtensionTest
    {
        [Fact]
        public void EnsureContentType_DefaultContentType_DoesNotThrowsException()
        {
            using var response1 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.UTF8, "application/json") };
            Assert.DoesNotThrows(() => response1.EnsureContentType());

            using var response2 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.ASCII, "text/html") };
            Assert.DoesNotThrows(() => response2.EnsureContentType("text/html; charset=us-ascii"));
        }

        [Theory]
        [InlineData("ASCII", "application/json")]
        [InlineData("UTF-8", "text/html")]
        public void EnsureContentType_NotUtf8ApplicationJson_ThrowsException(string encoding, string mediaType)
        {
            using var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty, Encoding.GetEncoding(encoding), mediaType)
            };

            Assert.Throws<HttpRequestException>(() => response.EnsureContentType());
        }

        [Fact]
        public async Task DeserializeAsync_Poco_PocoDeserialized()
        {
            // Arrange
            const string json = @"{
                                    ""age"": 35,
                                    ""name"": ""Peter"",
                                    ""enabled"": true
                                  }";

            using var response = new HttpResponseMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Act
            var result = await response.DeserializeAsync<ViewModelDummy>();

            // Assert
            Assert.Equal(35, result!.Age);
            Assert.Equal("Peter", result.Name);
            Assert.True(result.Enabled);
        }

        [Fact]
        public async Task DeserializeAsync_Literal_LiteralDeserialized()
        {
            // Arrange
            const string json = "true";

            using var response = new HttpResponseMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            // Act
            var result = await response.DeserializeAsync<bool>();

            // Assert
            Assert.True(result);
        }
    }
}
