using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;
using Krafted.Extensions;
using Krafted.Guards;

namespace System.Net.Http
{
    /// <summary>
    /// Provides extension methods to <see cref="HttpResponseMessage"/>.
    /// </summary>
    public static class HttpResponseMessageExtension
    {
        /// <summary>
        /// Throws an exception if the System.Net.Http.HttpResponseMessage.Headers.ContentType property for
        /// the HTTP response is different of <paramref name="defaultContentType"/> argument, whose default value is "application/json; charset=utf-8".
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="defaultContentType">The default content type. That is: application/json; charset=utf-8.</param>
        /// <returns>The HTTP response message if the call is successful.</returns>
        /// <exception cref="HttpRequestException">The HTTP response content type is different of the expected.</exception>
        /// <exception cref="ArgumentNullException">The response is null.</exception>
        public static HttpResponseMessage EnsureContentType(this HttpResponseMessage response, string defaultContentType = "application/json; charset=utf-8")
        {
            Guard.Against.Null(response, nameof(response));

            string contentType = response.Content.Headers.ContentType.ToString();

            if (!contentType.Equals(defaultContentType, StringComparison.OrdinalIgnoreCase))
                throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, Texts.IncorrectContentType, defaultContentType));

            return response;
        }

        /// <summary>
        /// Deserializes the <see cref="HttpResponseMessage"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="response">The HttpResponse.</param>
        /// <param name="propertyNameCaseInsensitive">
        /// Gets or sets a value that determines whether a property's name uses a case-insensitive
        /// comparison during deserialization. The default value is false.
        /// </param>
        /// <returns>The deserialized <typeparamref name="T"/> from the <see cref="HttpResponseMessage"/>.</returns>
        public static async Task<T> DeserializeAsync<T>(this HttpResponseMessage response, bool propertyNameCaseInsensitive = true)
        {
            Guard.Against.Null(response, nameof(response));
            return await DoDeserializeAsync<T>(response, propertyNameCaseInsensitive).ConfigureAwait(false);
        }

        private static async Task<T> DoDeserializeAsync<T>(HttpResponseMessage response, bool propertyNameCaseInsensitive)
        {
            var value = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = propertyNameCaseInsensitive });
        }
    }
}
