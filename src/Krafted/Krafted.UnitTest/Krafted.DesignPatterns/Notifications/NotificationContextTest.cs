using System.Collections.Generic;
using System.Linq;
using Krafted.DesignPatterns.Notifications;
using Krafted.DesignPatterns.Notifications.Abstractions;
using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class NotificationContextTest
    {
        [Fact]
        public void AddNotification_Notification_NotificationAdded()
        {
            var newNotification = new Notification("my_key", "My message", false);

            var context = new NotificationContext();
            context.AddNotification(newNotification);

            var notification = context.Notifications.First();

            Assert.True(context.HasNotifications);
            Assert.Equal(1, context.Notifications.Count);
            Assert.Equal(newNotification, notification);
        }

        [Fact]
        public void AddNotification_Notifications_NotificationsAdded()
        {
            var newNotifications = new List<Notification>
            {
                new Notification("my_key", "My message", false),
                new Notification("my_key2", "My message 2", false)
            };

            var context = new NotificationContext();
            context.AddNotifications(newNotifications);

            var notification1 = context.Notifications.First();
            var notification2 = context.Notifications.Second();

            Assert.True(context.HasNotifications);
            Assert.Equal(2, context.Notifications.Count);
            Assert.Equal(newNotifications.First(), notification1);
            Assert.Equal(newNotifications.Second(), notification2);
        }
    }
}
