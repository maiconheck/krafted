using System.Collections.Generic;
using System.Linq;
using Krafted.DesignPatterns.Notifications.Abstractions;

namespace Krafted.DesignPatterns.Notifications
{
    /// <inheritdoc cref="INotificationContext"/>
    public sealed class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications;

        public NotificationContext() => _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public void AddNotification(Notification notification)
            => _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications)
            => _notifications.AddRange(notifications);
    }
}
