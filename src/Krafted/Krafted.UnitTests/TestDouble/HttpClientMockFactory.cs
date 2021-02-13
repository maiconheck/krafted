using System;
using System.Net;
using System.Net.Http;

namespace Krafted.UnitTests.TestDouble
{
    /// <summary>
    /// Provides a Factory Method to create a <see cref="HttpMessageHandlerMock"/>.
    /// </summary>
    public static class HttpClientMockFactory
    {
        /// <summary>
        /// Creates a mock to the <see cref="HttpClient"/>.
        /// <seealso cref="HttpMessageHandlerMock"/>
        /// </summary>
        /// <param name="response">The response content that will be returned.</param>
        /// <param name="statusCode">The HTTP status code that will be returned.</param>
        /// <returns>A mock to the <see cref="HttpClient"/>.</returns>
        public static HttpClient New(string response, HttpStatusCode statusCode)
        {
            using (var messageHandler = new HttpMessageHandlerMock(response, statusCode))
            {
                return new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri("http://nothing")
                };
            }
        }
    }
}
