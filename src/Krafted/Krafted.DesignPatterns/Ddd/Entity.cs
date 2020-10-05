// A Entity base class implementation.
//
// The equality operations was based in this Khorikov's great article: Entity Base Class.
// Source: https://enterprisecraftsmanship.com/posts/entity-base-class/
// Retrieved in October 2020.

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Krafted.DesignPatterns.Notifications;

namespace Krafted.DesignPatterns.Ddd
{
    /// <summary>
    /// Represents an Entity [Evans] base class, providing an identity and common operations to entities.
    /// If you need <c>Domain Events</c>, implement the <see cref="IDomainEventCollection"/> interface and use the <see cref="EntityExtension"/>.
    /// If you need <c>Domain Notifications</c>, implement the <see cref="IDomainNotificationCollection"/> interface and use the <see cref="NotificationExtension"/>.
    /// </summary>
    /// <remarks>
    /// The <c>long</c> type usually is a good choice for the <see cref="Id"/>.
    /// But if you need a different type for the <see cref="Id"/> (maybe in legacy systems), grab a copy of this class, and re implement them accordingly.
    /// Don't try to use generics to the <see cref="Id"/> in order to avoid turning your entity base class in a <see href="https://wiki.c2.com/?GodClass">God Class</see>.
    /// </remarks>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual long Id { get; protected set; }

        /// <summary>
        /// Gets the actual object.
        /// </summary>
        /// <remarks>
        /// This serves to call Actual.GetType() in order to get the actual type of the object.
        /// It was added to the base class, in order to overcome the issue where ORMs return the type of a runtime proxy if you just call GetType() on an object.
        /// </remarks>
        /// <value>
        /// The actual object.
        /// </value>
        [NotMapped]
        protected virtual object Actual => this;

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
        public override int GetHashCode() => (Actual.GetType().ToString() + Id).GetHashCode(StringComparison.Ordinal);
    }
}
