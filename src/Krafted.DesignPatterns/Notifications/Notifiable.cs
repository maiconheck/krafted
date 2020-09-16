using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;
using Krafted.Guards;

namespace Krafted.DesignPatterns.Notifications
{
    /// <summary>
    /// Represents the notifiable class, to be used as the base class of the models that should contains notifications.
    /// </summary>
    public abstract class Notifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notifiable"/> class.
        /// </summary>
        protected Notifiable()
        {
            // Initial state is valid.
            Valid = true;
            _notifications = new List<Notification>();
        }

        /// <summary>
        /// Gets a value indicating whether this model is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        public bool Valid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this model is invalid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invalid; otherwise, <c>false</c>.
        /// </value>
        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        private readonly List<Notification> _notifications;

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications => _notifications;

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="localizedMessage">
        ///   The localized resource name that contains the message of the resource that was created.
        ///   If the localized message was not found, the value passed will be used as fall-back.
        /// </param>
        internal void AddNotification(string localizedMessage)
        {
            _notifications.Add(new Notification(localizedMessage, localizedMessage, true));
        }

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="validationResult">The validationResult.</param>
        internal void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.Add(new Notification(error.ErrorCode, error.ErrorMessage, false));
            }
        }

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="validator">The validator.</param>
        /// <returns><c>true</c> if valid; otherwise, <c>false</c>.</returns>
        protected bool Validate<T>(T entity, AbstractValidator<T> validator)
        {
            Guard.Against.Null(entity, nameof(entity)).Null(validator, nameof(validator));

            var validationResult = validator.Validate(entity);
            AddNotifications(validationResult);

            return Valid = validationResult.IsValid;
        }
    }
}
