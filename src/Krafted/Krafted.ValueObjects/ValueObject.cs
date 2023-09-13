#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an Value Object [Evans] base class, providing common operations to value objects.
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The value object a.</param>
        /// <param name="b">The value object b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ValueObject a, ValueObject b)
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
        /// <param name="a">The value object a.</param>
        /// <param name="b">The value object b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(ValueObject a, ValueObject b)
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
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="ValueObject"/>.
        /// </summary>
        /// <returns>A shallow copy of the current <see cref="ValueObject"/>.</returns>
        public ValueObject GetCopy() => MemberwiseClone() as ValueObject;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Gets the equality components.
        /// </summary>
        /// <remarks>
        /// This method must be implemented by the value objects that inherit from this class, to make
        /// the comparison between all the attributes (since a value object must not be based on identity).
        ///   <example>
        ///     <code>
        ///     protected override IEnumerable{object} GetEqualityComponents()
        ///     {
        ///         // Using a yield return statement to return each element one at a time
        ///         yield return Street;
        ///         yield return City;
        ///         yield return State;
        ///         yield return Country;
        ///         yield return ZipCode;
        ///     }
        ///     </code>
        ///   </example>
        /// </remarks>
        /// <returns>
        /// The equality components.
        /// </returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
