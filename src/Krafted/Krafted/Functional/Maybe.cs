using System;

namespace Krafted.Functional
{
    /// <summary>
    /// Represents a maybe monad.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public sealed class Maybe<T>
    {
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        internal Maybe(T value) => _value = value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        internal Maybe()
        {
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentNullException">Occurs if the value is null.</exception>
        public T Value
        {
            get
            {
                if (HasNoValue)
                    throw new ArgumentNullException(nameof(Value));

                return _value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </value>
        public bool HasValue => _value != null;

        /// <summary>
        /// Gets a value indicating whether this instance has no value.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has no value; otherwise, <c>false</c>.
        /// </value>
        public bool HasNoValue => !HasValue;

        /// <summary>
        /// Performs an implicit conversion from <see cref="T"/> to <see cref="Maybe{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);
    }
}
