using System.Net.Http;
using System.Threading.Tasks;
using Krafted.Api;
using Krafted.Test.Result;
using Newtonsoft.Json;
using SharedKernel.Application.Commands.Result.Default;

namespace Krafted.Test
{
    public abstract class IntegrationTest<TEntryPoint>
        where TEntryPoint : class
    {
        protected const string CorrectContentType = "application/json; charset=utf-8";

        private readonly ProviderStateApiFactory<TEntryPoint> _factory;

        protected IntegrationTest(ProviderStateApiFactory<TEntryPoint> factory, string endPoint)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            EndPoint = endPoint;
        }

        public string EndPoint { get; }

        protected HttpClient Client { get; }

        /// <summary>
        /// Ensures the success status code throwing an exception if the System.Net.Http.HttpResponseMessage.IsSuccessStatusCode
        /// property for the HTTP response is false (status Code 200-299.)
        /// </summary>
        /// <param name="response">The response.</param>
        protected static void EnsureSuccessStatusCode(HttpResponseMessage response) => response.EnsureSuccessStatusCode();

        protected static async Task<ResponseCommandResult> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);
            var data = JsonConvert.DeserializeAnonymousType(value, new { data = new { id = string.Empty } });

            return new ResponseCommandResult(data.data.id, content.Success, content.Message);
        }

        protected static async Task<ResponseCommandResult> DeserializeDeleteResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);

            return new ResponseCommandResult(content.Success, content.Message);
        }
    }
}