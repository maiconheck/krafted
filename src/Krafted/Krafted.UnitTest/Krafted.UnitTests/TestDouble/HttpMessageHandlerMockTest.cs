using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Krafted.UnitTests.TestDouble;
using Xunit;

namespace Krafted.UnitTest.Krafted.UnitTests.TestDouble
{
    [Trait(nameof(UnitTest), "Krafted.UnitTests.TestDouble")]
    public class HttpMessageHandlerMockTest
    {
        [Fact]
        public void New_ValidParameters_ProperInstantiated()
        {
            var httpClient = HttpClientMockFactory.New(string.Empty, HttpStatusCode.OK);
            Assert.NotNull(httpClient);
        }

        [Fact]
        public async Task Get_ResponseAndHttpStatus200OK_ResponseAndHttpStatus200OKGet()
        {
            // Arrange
            const string response = @"
{
  ""age"": 35,
  ""name"": ""Maicon Heck"",
  ""enabled"": true
}";

            var httpClient = HttpClientMockFactory.New(response, HttpStatusCode.OK);

            // Act
            var getResponse = await httpClient.GetAsync("/api/nothing");
            var getResponseDeserialized = await getResponse.DeserializeAsync<ViewModelDummy>();

            // Assert
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.Equal(35, getResponseDeserialized!.Age);
            Assert.Equal("Maicon Heck", getResponseDeserialized.Name);
            Assert.True(getResponseDeserialized.Enabled);
        }
    }
}
