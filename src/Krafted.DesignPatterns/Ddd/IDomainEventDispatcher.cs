using System.Threading.Tasks;

namespace Krafted.Ddd
{
    /// <summary>
    /// Defines an dispatcher to the domain events.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// Dispatches an domain event asynchronously.
        /// </summary>
        /// <param name="event">The domain event.</param>
        /// <returns>The task.</returns>
        Task DispatchAsync(IDomainEvent @event);
    }
}
