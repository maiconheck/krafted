using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using Krafted.DesignPatterns.Notifications;
using Krafted.Guards;

namespace Krafted.Ddd
{
    /// <summary>
    /// Represents an Entity [Evans] base class, providing an identity and common operations to entities.
    /// </summary>
    public abstract class Entity : Notifiable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual long Id { get; protected set; }

        [NotMapped]
        protected virtual object Actual => this;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The entity a.</param>
        /// <param name="b">The entity b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The entity a.</param>
        /// <param name="b">The entity b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Entity a, Entity b)
            => !(a == b);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => (Actual.GetType().ToString() + Id).GetHashCode();

        /// <summary>
        /// Publishes the event.
        /// </summary>
        /// <param name="event">The event.</param>
        protected void PublishEvent(IDomainEvent @event)
        {
            Guard.Against.Null(@event, nameof(@event));
            _domainEvents.Enqueue(@event);
        }
    }
}
