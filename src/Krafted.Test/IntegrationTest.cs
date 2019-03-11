using System.Net.Http;
using System.Threading.Tasks;
using Krafted.Api;
using Krafted.Test.Result;
using Newtonsoft.Json;
using SharedKernel.Application.Commands.Result.Default;

namespace Krafted.Test
{
    /// <summary>
    /// Represents the IntegrationTest base class.
    /// </summary>
    /// <typeparam name="TEntryPoint">The type of the t entry point.</typeparam>
    public abstract class IntegrationTest<TEntryPoint>
        where TEntryPoint : class
    {
        /// <summary>
        /// The correct content type. That is: application/json; charset=utf-8
        /// </summary>
        protected const string CorrectContentType = "application/json; charset=utf-8";

        private readonly ProviderStateApiFactory<TEntryPoint> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest{TEntryPoint}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="endPoint">The end point.</param>
        protected IntegrationTest(ProviderStateApiFactory<TEntryPoint> factory, string endPoint)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            EndPoint = endPoint;
        }

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public string EndPoint { get; }

        /// <summary>
        /// Gets the <see cref="HttpClient"/>.
        /// </summary>
        /// <value>The <see cref="HttpClient"/>.</value>
        protected HttpClient Client { get; }

        /// <summary>
        /// Ensures the success status code throwing an exception if the System.Net.Http.HttpResponseMessage.IsSuccessStatusCode
        /// property for the HTTP response is false (status Code 200-299.)
        /// </summary>
        /// <param name="response">The response.</param>
        protected static void EnsureSuccessStatusCode(HttpResponseMessage response) => response.EnsureSuccessStatusCode();

        /// <summary>
        /// Deserialize the response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/>.</returns>
        protected static async Task<ResponseCommandResult> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);
            var data = JsonConvert.DeserializeAnonymousType(value, new { data = new { id = string.Empty } });

            return new ResponseCommandResult(data.data.id, content.Success, content.Message);
        }

        /// <summary>
        /// deserialize the delete response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/></returns>
        protected static async Task<ResponseCommandResult> DeserializeDeleteResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);

            return new ResponseCommandResult(content.Success, content.Message);
        }
    }
}