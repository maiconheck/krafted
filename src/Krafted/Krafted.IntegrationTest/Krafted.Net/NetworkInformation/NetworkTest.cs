using System;
using Krafted.Net.NetworkInformation;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Net.NetworkInformation
{
    [Trait(nameof(IntegrationTest), "Krafted.Net")]
    public class NetworkTest
    {
        [Fact]
        public void Available_ExistentHostname_True()
        {
            var (isAvailable, resultMessage) = Network.Available("localhost");

            Assert.True(isAvailable);
            Assert.Equal("Status: Success", resultMessage);
        }

        [Fact]
        public void Available_InexistentHostname_False()
        {
            var (isAvailable, resultMessage) = Network.Available("maiconheck.com.br");

            Assert.False(isAvailable);
            Assert.Contains("An exception occurred during a Ping request.", resultMessage, StringComparison.Ordinal);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Available_InvalidHostName_ThrowsException(string hostname)
        {
            Assert.Throws<ArgumentNullException>(() => Network.Available(hostname));
        }
    }
}
