using System;
using Krafted.Guards;
using Krafted.Localization.Abstractions;
using Krafted.Rfc.ProblemDetails.Types;

namespace Krafted.Rfc.ProblemDetails
{
    /// <summary>
    /// A factory method to create a <see cref="SuccessResponse"/> or a <see cref="FailResponse"/>,
    /// in an standard format and with a proper HTTP Status Code, to be used as the return of the Command Handlers.
    /// <see href="https://jsonapi.org/format/#crud-updating-relationship-responses-204">crud-updating-relationship-responses-204</see>
    /// <see href="https://www.restapitutorial.com/httpstatuscodes.html">httpstatuscodes</see>
    /// <see href="https://restfulapi.net/http-status-codes/">http-status-codes</see>.
    /// </summary>
    public static class Response
    {
        private static ILocalizerService _localizerService;

        /// <summary>
        /// Configures the specified localizer service.
        /// </summary>
        /// <param name="localizerService">The localizer service.</param>
        public static void Configure(ILocalizerService localizerService)
        {
            Guard.Against.Null(localizerService, nameof(localizerService));
            _localizerService = localizerService;
        }

        /// <summary>
        /// Creates a <see cref="SuccessResponse" /> for a GET that indicates that there are results in it - [200 OK].
        /// It should be used for the GET response when there are results.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response to create the <see cref="IResponse"/>.</typeparam>
        /// <param name="data">The data that will be sent to the client in the response (e.g. a DTO).</param>
        /// <returns>A <see cref="SuccessResponse" /> for a GET that indicates that there are results in it.</returns>
        public static SuccessResponse Ok<TResponse>(TResponse data) where TResponse : class
            => new SuccessResponse(ResponseType.Ok, data, StatusCodes.Status200OK);

        /// <summary>
        /// Creates a <see cref="SuccessResponse" /> for a PUT or DELETE, that indicates that the request was successfully processed, and the result is returned to the client - [200 Ok].
        /// It should be used for the PUT and DELETE response when operation succeeded.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response to create the <see cref="IResponse"/>.</typeparam>
        /// <param name="title">The 'title' that will be sent to the client in the response message.</param>
        /// <param name="data">The data that will be sent to the client in the response (e.g. a DTO).</param>
        /// <returns>A <see cref="SuccessResponse" /> for a PUT, PATCH or DELETE that indicates that the request was processed, but there is no content to be returned.</returns>
        public static SuccessResponse Ok<TResponse>(TitleOk title, TResponse data) where TResponse : class
        {
            Guard.Against
                .Null(title, nameof(title))
                .Null(data, nameof(data));

            string detail = (title.HttpMethod == HttpMethod.Put)
                ? "Please refer to the data property for additional details."
                : string.Empty;

            return new SuccessResponse(ResponseType.Ok, data, StatusCodes.Status200OK, title.Title, detail);
        }

        /// <summary>
        /// Creates a <see cref = "SuccessResponse" /> for a POST that indicates that a resource was created - [201 Created].
        /// It should be used for the POST response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response to create the <see cref="IResponse"/>.</typeparam>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        /// <param name="data">The data that will be sent to the client in the response (e.g. a DTO).</param>
        /// <returns>A <see cref = "SuccessResponse" /> for a POST that indicates that a resource was created.</returns>
        public static SuccessResponse CreatedAtAction<TResponse>(string localizedMessage, TResponse data) where TResponse : class
        {
            Guard.Against
                .NullOrWhiteSpace(localizedMessage, nameof(localizedMessage))
                .Null(data, nameof(data));

            string message = _localizerService.GetValue(localizedMessage);
            return new SuccessResponse(ResponseType.CreatedAtAction, data, StatusCodes.Status201Created, message);
        }

        /// <summary>
        /// Creates a <see cref = "SuccessResponse" /> for a POST that indicates that a resource was created - [201 Created].
        /// It should be used for the POST response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response to create the <see cref="IResponse"/>.</typeparam>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        /// <param name="resourceName">The name of the resource to be replaced in the localizedMessage.</param>
        /// <param name="data">The data that will be sent to the client in the response (e.g. a DTO).</param>
        /// <returns>A <see cref = "SuccessResponse" /> for a POST that indicates that a resource was created.</returns>
        public static SuccessResponse CreatedAtAction<TResponse>(string localizedMessage, string resourceName, TResponse data) where TResponse : class
        {
            Guard.Against
                .NullOrWhiteSpace(localizedMessage, nameof(localizedMessage))
                .NullOrWhiteSpace(resourceName, nameof(resourceName))
                .Null(data, nameof(data));

            string message = _localizerService.GetValue(localizedMessage).Format(resourceName);
            return new SuccessResponse(ResponseType.CreatedAtAction, data, StatusCodes.Status201Created, message);
        }

        /// <summary>
        /// Creates a <see cref="FailResponse" /> indicates that the resource was not found (e.g. the entity) - [404 Not Found].
        /// </summary>
        /// <param name="resourceName">The name of the resource that was not found.</param>
        /// <param name="id">The resource identifier that was not found.</param>
        /// <returns>A <see cref="FailResponse" /> that indicates that the resource was not found.</returns>
        public static FailResponse NotFound(string resourceName, int id) => new FailResponse(GetResourceName(resourceName, id));

        /// <summary>
        /// Creates a <see cref="FailResponse" /> indicates that the resource was not found (e.g. the entity) - [404 Not Found].
        /// </summary>
        /// <param name="resourceName">The name of the resource that was not found.</param>
        /// <returns>A <see cref="FailResponse" /> that indicates that the resource was not found.</returns>
        public static FailResponse NotFound(string resourceName) => new FailResponse(resourceName);

        /// <summary>
        /// Creates a <see cref="FailResponse" /> indicates that was an error in the request - [400 Bad Request].
        /// It should be used to indicate any business problem.
        /// </summary>
        /// <returns>A <see cref="FailResponse" /> that indicates that was an error in the request.</returns>
        public static FailResponse BadRequest() => new FailResponse();

        /// <summary>
        /// Gets the resource name.
        /// </summary>
        /// <param name="resourceName">The name of the resource that was not found.</param>
        /// <param name="id">The resource identifier that was not found.</param>
        /// <returns>The resource name.</returns>
        private static string GetResourceName(string resourceName, int id)
        {
            Guard.Against.NullOrWhiteSpace(resourceName, nameof(resourceName));
            return $"{resourceName} {id}";
        }
    }
}
