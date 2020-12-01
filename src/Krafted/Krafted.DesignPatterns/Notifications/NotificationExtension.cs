using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Krafted.DesignPatterns.Ddd;
using Krafted.DesignPatterns.Notifications.Abstractions;
using Krafted.Guards;

namespace Krafted.DesignPatterns.Notifications
{
    /// <summary>
    /// Provides extension methods to the <see cref="IDomainNotificationCollection"/>.
    /// </summary>
    public static class NotificationExtension
    {
        /// <summary>
        /// Gets a value indicating whether the model is valid.
        /// </summary>
        /// <param name="model">The model to check.</param>
        /// <returns>
        ///   <c>true</c> if the model is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool Valid(this IDomainNotificationCollection model)
            => !model.Notifications.Any();

        /// <summary>
        /// Gets a value indicating whether the model is invalid.
        /// </summary>
        /// <param name="model">The model to check.</param>
        /// <returns>
        ///   <c>true</c> if the model is invalid; otherwise, <c>false</c>.
        /// </returns>
        public static bool Invalid(this IDomainNotificationCollection model)
            => model.Notifications.Any();

        /// <summary>
        /// Gets a value indicating whether all models of the models parameter are valid.
        /// </summary>
        /// <param name="models">The models to check.</param>
        /// <returns>
        ///   <c>true</c> if all models are valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool AllValid(this IEnumerable<IDomainNotificationCollection> models)
            => models.All(Valid);

        /// <summary>
        /// Gets a value indicating whether any model of the models parameter are invalid.
        /// </summary>
        /// <param name="models">The models to check.</param>
        /// <returns>
        ///   <c>true</c> if any models are invalid; otherwise, <c>false</c>.
        /// </returns>
        public static bool AnyInvalid(this IEnumerable<IDomainNotificationCollection> models)
            => models.Any(Invalid);

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        public static void AddNotification(this IList<Notification> notifications, string localizedMessage)
        {
            Guard.Against.NullOrWhiteSpace(localizedMessage, nameof(localizedMessage));
            notifications.Add(new Notification(localizedMessage, localizedMessage, true));
        }

        /// <summary>
        /// Validates the specified model using an <see cref="AbstractValidator{T}"/> of FluentValidation.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="notifications">The notifications.</param>
        /// <param name="validator">The validator.</param>
        /// <returns><c>true</c> if valid; otherwise, <c>false</c>.</returns>
        public static bool Validate<T>(this T model, IList<Notification> notifications, AbstractValidator<T> validator)
            where T : class, IDomainNotificationCollection
        {
            Guard.Against
                .Null(notifications, nameof(notifications))
                .Null(validator, nameof(validator));

            var validationResult = validator.Validate(model);
            AddNotifications(notifications, validationResult);

            return model.Valid();
        }

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="notifications">The notifications.</param>
        /// <param name="validationResult">The validationResult.</param>
        internal static void AddNotifications(this IList<Notification> notifications, ValidationResult validationResult)
        {
            Guard.Against
                .Null(notifications, nameof(notifications))
                .Null(validationResult, nameof(validationResult));

            foreach (var error in validationResult.Errors)
            {
                notifications.Add(new Notification(error.ErrorCode, error.ErrorMessage, false));
            }
        }
    }
}
