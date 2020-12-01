using System;
using System.ComponentModel;
using Krafted.Guards;
using Krafted.Localization.Abstractions;

namespace Krafted.Rfc.ProblemDetails
{
    /// <summary>
    /// Generates a standard title to be used in the PUT and DELETE response messages.
    /// </summary>
    /// <remarks>
    /// 'title' is a property in the RFC 7807 spec (Problem Details for HTTP APIs).
    /// As RFC 7807 spec defines the 'title' property for the error messages, we also use the name 'title' for other messages, instead of using 'message', for example.
    /// </remarks>
    /// <see href="https://tools.ietf.org/html/rfc7807">See rfc7807.</see>
    public sealed class TitleOk
    {
        private static ILocalizerService _localizerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleOk"/> class.
        /// </summary>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        /// <param name="method">The <see cref="HttpMethod"/> method.</param>
        /// <exception cref="InvalidEnumArgumentException">method.</exception>
        public TitleOk(string localizedMessage, HttpMethod method)
            => Initialize(localizedMessage, method);

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleOk"/> class.
        /// </summary>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        /// <param name="resourceName">The name of the resource to be replaced in the localizedMessage.</param>
        /// <param name="method">The <see cref="HttpMethod"/> method.</param>
        /// <exception cref="InvalidEnumArgumentException">method.</exception>
        public TitleOk(string localizedMessage, string resourceName, HttpMethod method)
        {
            Guard.Against.NullOrWhiteSpace(resourceName, nameof(resourceName));

            Initialize(localizedMessage, method);
            Title = Title.Format(resourceName);
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets either the PUT or DELETE method.
        /// </summary>
        /// <value>The PUT or DELETE method.</value>
        public HttpMethod HttpMethod { get; private set; }

        /// <summary>
        /// Configures the specified localizer service.
        /// </summary>
        /// <param name="localizerService">The localizer service.</param>
        public static void Configure(ILocalizerService localizerService)
        {
            Guard.Against.Null(localizerService, nameof(localizerService));
            _localizerService = localizerService;
        }

        private void Initialize(string localizedMessage, HttpMethod method)
        {
            Guard.Against.NullOrWhiteSpace(localizedMessage, nameof(localizedMessage));

            if (method != HttpMethod.Put && method != HttpMethod.Delete)
            {
                throw new InvalidEnumArgumentException(nameof(method), (int)method, typeof(HttpMethod));
            }

            HttpMethod = method;
            Title = _localizerService.GetValue(localizedMessage);
        }
    }
}
