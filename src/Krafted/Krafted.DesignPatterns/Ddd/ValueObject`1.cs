using System;
using System.Collections.Generic;
using System.Linq;

namespace Krafted.DesignPatterns.Ddd
{
    /// <summary>
    /// Represents an Value Object [Evans] base class for a single value, providing common operations to value objects.
    /// See <see cref="Value"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public abstract class ValueObject<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual T Value { get; protected set; }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The value object a.</param>
        /// <param name="b">The value object b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
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
        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
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

            var other = (ValueObject<T>)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="ValueObject"/>.
        /// </summary>
        /// <returns>A shallow copy of the current <see cref="ValueObject"/>.</returns>
        public ValueObject<T> GetCopy() => MemberwiseClone() as ValueObject<T>;

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
        /// Returns the string representation of <see cref="Value"/>.
        /// </summary>
        /// <returns>The the string representation of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString();

        /// <summary>
        /// Returns the string representation of <see cref="Value"/> as specified by <see cref="IFormatProvider"/> provider.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The the string representation of <see cref="Value"/> as specified by <see cref="IFormatProvider"/> provider.</returns>
        public virtual string ToString(IFormatProvider provider) => Value.ToString(provider);

        /// <summary>
        /// Gets the equality components to make the comparison, since a value object must not be based on identity.
        /// </summary>
        /// <returns>
        /// The equality components.
        /// </returns>
        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
