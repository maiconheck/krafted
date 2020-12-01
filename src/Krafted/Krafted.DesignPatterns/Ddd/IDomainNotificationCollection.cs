using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Krafted.DesignPatterns.Notifications.Abstractions;

namespace Krafted.DesignPatterns.Ddd
{
    /// <summary>
    /// Defines a collection of <see cref="Notification"/>.
    /// </summary>
    public interface IDomainNotificationCollection
    {
        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        [NotMapped]
        public IReadOnlyCollection<Notification> Notifications { get; }
    }
}
