using System.Collections.Concurrent;
using Krafted.Guards;

namespace Krafted.DesignPatterns.Ddd
{
    /// <summary>
    /// Provides extension methods to <see cref="Entity"/>.
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// Publishes an domain event.
        /// </summary>
        /// <param name="domainEvents">The domain events.</param>
        /// <param name="event">The domain event.</param>
        public static void PublishEvent(this ConcurrentQueue<IDomainEvent> domainEvents, IDomainEvent @event)
        {
            Guard.Against
                .Null(domainEvents, nameof(domainEvents))
                .Null(@event, nameof(@event));

            domainEvents.Enqueue(@event);
        }
    }
}
