using System;
using System.Linq;
using Flunt.Notifications;

namespace Krafted.Data
{
    /// <summary>
    /// Represents the entity base.
    /// </summary>
    /// <seealso cref="Notifiable" />
    public abstract class Entity : Notifiable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Adds the invalid notifications.
        /// </summary>
        /// <param name="notifications">The items.</param>
        protected void AddNotificationsIfInvalid(params Notifiable[] notifications)
            => AddNotifications(notifications.Where(n => n.Invalid).ToArray());
    }
}