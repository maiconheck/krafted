using System.Net.NetworkInformation;
using Krafted.Guards;

namespace Krafted.Net.NetworkInformation
{
    /// <summary>
    /// Provides network information methods.
    /// </summary>
    public static class Network
    {
        /// <summary>
        /// Checks whether an host name or IP address is available.
        /// </summary>
        /// <param name="hostNameOrAddress">The host name or address that identifies the computer that is the destination for the check.</param>
        /// <returns><c>true</c> if available; otherwise, <c>false</c>. In both cases, containing a message describing the result.</returns>
        public static (bool isAvailable, string resultMessage) Available(string hostNameOrAddress)
        {
            Guard.Against.NullOrWhiteSpace(hostNameOrAddress);

            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send(hostNameOrAddress);
                    bool isAvailable = reply.Status == IPStatus.Success;

                    return (isAvailable, $"Status: {reply.Status}");
                }
            }
            catch (PingException ex)
            {
                return (false, $"{ex.Message} {ex.InnerException!.Message}");
            }
        }
    }
}
