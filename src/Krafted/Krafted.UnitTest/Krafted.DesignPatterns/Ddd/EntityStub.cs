using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Krafted.DesignPatterns.Ddd;
using Krafted.DesignPatterns.Notifications;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    public class EntityStub : Entity, IDomainEventCollection, IDomainNotificationCollection
    {
        private bool _locked;

        public EntityStub(int age, string name, string email)
        {
            Age = age;
            Name = name;
            Email = email;

            this.Validate(_notifications, new EntityValidator());

            if (this.Valid())
            {
                _domainEvents.PublishEvent(new UserRegisteredEvent(name, email));
            }
        }

        [NotMapped]
        private readonly List<Notification> _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        [NotMapped]
        private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new ConcurrentQueue<IDomainEvent>();

        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>
        /// The domain events.
        /// </value>
        [NotMapped]
        public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

        public override long Id { get; protected set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Email { get; }

        public void Edit(int age, string name)
        {
            Age = age;
            Name = name;

            this.Validate(_notifications, new EntityValidator());
        }

        public void Lock()
        {
            if (_locked)
            {
                _notifications.AddNotification("UserAlreadyLocked");
            }
            else
            {
                _locked = true;
                _domainEvents.PublishEvent(new UserLockedEvent(Email));
            }
        }

        public void SetId(long id) => Id = id;
    }
}
