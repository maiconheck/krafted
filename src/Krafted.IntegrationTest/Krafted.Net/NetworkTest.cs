using Krafted.Net;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Net
{
    public class NetworkTest
    {
        [Fact]
        public void Available_ExistentHostname_True()
        {
            var (isAvailable, resultMessage) = Network.Available("maiconheck.com");

            Assert.True(isAvailable);
            Assert.Equal("Status: Success", resultMessage);
        }

        [Fact]
        public void Available_InexistentHostname_True()
        {
            var (isAvailable, resultMessage) = Network.Available("maiconheck.com.br");

            Assert.False(isAvailable);
            Assert.Equal("An exception occurred during a Ping request. No such host is known.", resultMessage);
        }
    }
}
