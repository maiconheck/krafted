using System.Collections.Generic;

namespace Krafted.DesignPatterns.Notifications
{
    /// <summary>
    /// Provides a context to manage the notifications.
    /// </summary>
    public interface INotificationContext
    {
        /// <summary>
        /// Gets a value indicating whether there are notifications.
        /// </summary>
        /// <value>
        ///   <c>true</c> if are notifications; otherwise, <c>false</c>.
        /// </value>
        bool HasNotifications { get; }

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <value>The notifications.</value>
        IReadOnlyCollection<Notification> Notifications { get; }

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="notification">The notification message.</param>
        void AddNotification(Notification notification);

        /// <summary>
        /// Adds a notification message.
        /// </summary>
        /// <param name="notifications">The collection of notifications messages.</param>
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}
