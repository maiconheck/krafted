using System.Collections.Generic;
using Krafted.DesignPatterns.Ddd;
using Krafted.DesignPatterns.Notifications;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    public class ModelStub : IDomainNotificationCollection
    {
        public ModelStub(int age, string name)
        {
            Age = age;
            Name = name;

            this.Validate(_notifications, new ModelStubValidator());
        }

        protected readonly List<Notification> _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public int Age { get; }

        public string Name { get; }

        public void AddNotification(string localizedMessage) => _notifications.AddNotification(localizedMessage);
    }
}
