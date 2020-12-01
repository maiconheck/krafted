using System.Collections.Generic;
using Krafted.DesignPatterns.Ddd;
using Krafted.DesignPatterns.Notifications;
using Krafted.DesignPatterns.Notifications.Abstractions;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    public class ModelStub : IDomainNotificationCollection
    {
        public ModelStub(int age, string name, bool enabled = false)
        {
            Age = age;
            Name = name;
            Enabled = enabled;

            this.Validate(_notifications, new ModelStubValidator());
        }

        private readonly List<Notification> _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public int Age { get; }

        public string Name { get; }

        public bool Enabled { get; }

        public void AddNotification(string localizedMessage) => _notifications.AddNotification(localizedMessage);
    }
}
