using System.Collections.Generic;
using System.Linq;
using Krafted.DesignPatterns.Notifications.Abstractions;
using Krafted.Guards;
using Krafted.Localization.Abstractions;

namespace Krafted.Rfc.ProblemDetails.Types
{
    /// <summary>
    /// Represents a fail response.
    /// </summary>
    /// <seealso cref="SuccessResponse" />
    public sealed class FailResponse : SuccessResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailResponse"/> class.
        /// </summary>
        public FailResponse()
            : base(
                   ResponseType.BadRequest,
                   null,
                   StatusCodes.Status400BadRequest,
                   "One or more validation errors occurred.",
                   "Please refer to the errors property for additional details")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailResponse"/> class.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        public FailResponse(string resourceName)
            : base(
                   ResponseType.NotFound,
                   null,
                   StatusCodes.Status404NotFound,
                   $"{resourceName} does not exist.",
                   "Please refer to the errors property for additional details")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FailResponse"/> class.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        /// <param name="localizerService">The localizer service.</param>
        public FailResponse(IReadOnlyCollection<Notification> notifications, ILocalizerService localizerService)
            : base(
                   ResponseType.BadRequest,
                   null,
                   StatusCodes.Status400BadRequest,
                   "One or more validation errors occurred.",
                   "Please refer to the errors property for additional details")
        {
            Guard.Against
                .Null(notifications, nameof(notifications))
                .Null(localizerService, nameof(localizerService));

            foreach (var notificationLocalized in notifications.Where(n => n.Localized))
            {
                notificationLocalized.Message = localizerService.GetValue(notificationLocalized.Key);
            }

            Errors = notifications;
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IReadOnlyCollection<Notification> Errors { get; }
    }
}
