using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Krafted.Test.Result;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Krafted.Net.Http
{
    /// <summary>
    /// Provides extension methods to <see cref="HttpResponseMessage"/>.
    /// </summary>
    public static class HttpResponseMessageExtension
    {
        /// <summary>
        /// Throws an exception if the System.Net.Http.HttpResponseMessage.Headers.ContentType property for the HTTP response is different of <paramref name="defaultContentType"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="defaultContentType">The default content type. That is: application/json; charset=utf-8.</param>
        /// <returns>The HTTP response message if the call is successful.</returns>
        /// <exception cref="HttpRequestException">The HTTP response content type is different of the expected.</exception>
        /// <exception cref="ArgumentNullException">The response is null.</exception>
        public static HttpResponseMessage EnsureContentType(this HttpResponseMessage response, string defaultContentType = "application/json; charset=utf-8")
        {
            ExceptionHelper.ThrowIfNull(() => response);

            if (!response.Content.Headers.ContentType.ToString().Equals(defaultContentType, StringComparison.OrdinalIgnoreCase))
                throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, Texts.IncorrectContentType, defaultContentType));

            return response;
        }

        /// <summary>
        /// Deserialize the response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/>.</returns>
        public static async Task<ResponseCommandResult> DeserializeAsync(this HttpResponseMessage response)
        {
            ExceptionHelper.ThrowIfNull(() => response);

            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            bool success = JObject.Parse(value).Value<bool>("success");

            if (success)
            {
                var successResult = JsonConvert.DeserializeAnonymousType(value, new
                {
                    data = new { id = string.Empty },
                    success = false,
                    failure = false,
                    message = string.Empty
                });

                if (successResult.data != null && successResult.data.id != null)
                    return new ResponseCommandResult(successResult.data.id, successResult.success, successResult.message);

                return new ResponseCommandResult(successResult.success, successResult.message);
            }

            var failureResult = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);
            return new ResponseCommandResult(failureResult.Success, failureResult.Message, failureResult.Data);
        }

        /// <summary>
        /// deserialize the delete response command asynchronous.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="ResponseCommandResult"/>.</returns>
        public static async Task<ResponseCommandResult> DeserializeDeleteAsync(this HttpResponseMessage response)
        {
            ExceptionHelper.ThrowIfNull(() => response);

            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var content = JsonConvert.DeserializeObject<DefaultDetailedCommandResult>(value);

            return new ResponseCommandResult(content.Success, content.Message);
        }
    }
}