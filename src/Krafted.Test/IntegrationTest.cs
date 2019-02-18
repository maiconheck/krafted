using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Krafted.Test.Result;
using Krafted.Api;
using Krafted.Framework.SharedKernel.Application.Commands.Result.ThirdParty;
using Krafted.Framework.SharedKernel.Application.Commands.Result.Default;

namespace Krafted.Test
{
    public abstract class IntegrationTest<TEntryPoint> where TEntryPoint : class
    {
        private readonly ProviderStateApiFactory<TEntryPoint> _factory;
        protected const string CorrectContentType = "application/json; charset=utf-8";

        protected IntegrationTest(ProviderStateApiFactory<TEntryPoint> factory, string endPoint)
        {
            _factory = factory;
            Client = _factory.CreateClient();
            EndPoint = endPoint;
        }

        public string EndPoint { get; }
        protected HttpClient Client { get; }

        /// <summary>
        /// Throws an exception if the System.Net.Http.HttpResponseMessage.IsSuccessStatusCode
        /// property for the HTTP response is false. (Status Code 200-299.)
        /// </summary>
        /// <param name="response">The HttpResponse</param>
        protected static void EnsureSuccessStatusCode(HttpResponseMessage response) => response.EnsureSuccessStatusCode();

        protected async Task<ResponseCommandResult> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);
            var data = JsonConvert.DeserializeAnonymousType(value, new { data = new { id = string.Empty } });

            return new ResponseCommandResult(data.data.id, content.Success, content.Message);
        }

        protected async Task<ResponseCommandResult> DeserializeDeleteResponseAsync(HttpResponseMessage response)
        {
            var value = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);

            return new ResponseCommandResult(content.Success, content.Message);
        }
    }
}