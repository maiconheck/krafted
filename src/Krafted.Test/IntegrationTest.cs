using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Krafted.Api;
using Krafted.Test.Result;
using Newtonsoft.Json;

namespace Krafted.Test
{
    /// <summary>
    /// Represents the IntegrationTest base class.
    /// </summary>
    /// <typeparam name="TEntryPoint">The type of the entry point.</typeparam>
    [ExcludeFromCodeCoverage]
    public abstract class IntegrationTest<TEntryPoint>
        where TEntryPoint : class
    {
        private readonly ProviderStateApiFactory<TEntryPoint> _factory;
        private readonly string _defaultContentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest{TEntryPoint}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="defaultContentType">The default content type. That is: application/json; charset=utf-8.</param>
        protected IntegrationTest(ProviderStateApiFactory<TEntryPoint> factory, string endPoint, string defaultContentType = "application/json; charset=utf-8")
        {
            ExceptionHelper.ThrowIfNull(() => factory, () => endPoint);

            _factory = factory;
            Client = _factory.CreateClient();
            EndPoint = endPoint;
            _defaultContentType = defaultContentType;
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
        /// Deserialize the response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/>.</returns>
        protected static async Task<ResponseCommandResult> DeserializeResponseAsync(HttpResponseMessage response)
        {
            response.ThrowIfNull(nameof(response));

            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);
            var data = JsonConvert.DeserializeAnonymousType(value, new { data = new { id = string.Empty } });

            return new ResponseCommandResult(data.data.id, content.Success, content.Message);
        }

        /// <summary>
        /// deserialize the delete response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/>.</returns>
        protected static async Task<ResponseCommandResult> DeserializeDeleteResponseAsync(HttpResponseMessage response)
        {
            response.ThrowIfNull(nameof(response));

            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);

            return new ResponseCommandResult(content.Success, content.Message);
        }

        /// <summary>
        /// Ensures the content type throwing an exception if the .
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The HTTP response message if the call is successful.</returns>
        /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
        protected HttpResponseMessage EnsureCorrectContentType(HttpResponseMessage response)
        {
            response.ThrowIfNull(nameof(response));

            if (response.Content.Headers.ContentType.ToString().Equals(_defaultContentType, StringComparison.OrdinalIgnoreCase))
                throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, Texts.IncorrectContentType, _defaultContentType));

            return response;
        }
    }
}