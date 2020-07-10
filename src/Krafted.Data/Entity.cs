using System;
using Flunt.Notifications;

namespace Krafted.Data
{
    /// <summary>
    /// Represents the entity base.
    /// </summary>
    /// <seealso cref="Notifiable" />
    public abstract class Entity : Notifiable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}
