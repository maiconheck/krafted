// A HttpMessageHandler mock implementation.
//
// This class is based on the excellent article: Mocking the HttpClient in .NET Core by Lars Richter.
// Link: https://dev.to/n_develop/mocking-the-httpclient-in-net-core-with-nsubstitute-k4j
// Source: https://github.com/n-develop/HttpClientMock
// Retrieved in February 2021.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Krafted.UnitTests.TestDouble
{
    /// <summary>
    /// Provides a mock to the <see cref="HttpClient"/>.
    /// </summary>
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        private readonly string _response;
        private readonly HttpStatusCode _statusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMessageHandlerMock"/> class.
        /// </summary>
        /// <param name="response">The response content that will be returned.</param>
        /// <param name="statusCode">The HTTP status code that will be returned.</param>
        public HttpMessageHandlerMock(string response, HttpStatusCode statusCode)
        {
            _response = response;
            _statusCode = statusCode;
        }

        /// <summary>
        /// Gets the number of times the method was called.
        /// </summary>
        /// <value>
        /// The number of times the method was called.
        /// </value>
        public int NumberOfCalls { get; private set; }

        /// <inheritdoc/>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            NumberOfCalls++;

            var response = new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_response)
            };

            return Task.FromResult(response);
        }
    }
}
