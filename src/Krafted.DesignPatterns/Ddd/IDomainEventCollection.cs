using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace Krafted.DesignPatterns.Ddd
{
    /// <summary>
    /// Defines a collection of <see cref="IDomainEvent"/>.
    /// </summary>
    public interface IDomainEventCollection
    {
        /// <summary>
        /// Gets the domain events.
        /// </summary>
        /// <value>
        /// The domain events.
        /// </value>
        [NotMapped]
        IProducerConsumerCollection<IDomainEvent> DomainEvents { get; }
    }
}
