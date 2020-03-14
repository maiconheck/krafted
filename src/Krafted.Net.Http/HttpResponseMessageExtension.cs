using System;
using System.Globalization;
using System.Net.Http;

namespace Krafted.Net.Http
{
    public static class HttpResponseMessageExtension
    {
        /// <summary>
        /// Throws an exception if the System.Net.Http.HttpResponseMessage.Headers.ContentType property for the HTTP response is different of <paramref name="defaultContentType"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="defaultContentType">The default content type. That is: application/json; charset=utf-8.</param>
        /// <returns>The HTTP response message if the call is successful.</returns>
        /// <exception cref="HttpRequestException">The HTTP response content type is different of the expected.</exception>
        public static HttpResponseMessage EnsureContentType(
            this HttpResponseMessage response,
            string defaultContentType = "application/json; charset=utf-8")
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            if (!response.Content.Headers.ContentType.ToString().Equals(defaultContentType, StringComparison.OrdinalIgnoreCase))
                throw new HttpRequestException(string.Format(CultureInfo.InvariantCulture, Texts.IncorrectContentType, defaultContentType));

            return response;
        }
    }
}