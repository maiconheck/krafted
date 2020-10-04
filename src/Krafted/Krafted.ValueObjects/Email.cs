using Krafted.Guards;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an email value object.
    /// </summary>
    public sealed class Email : IValueObject<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Email(string value)
        {
            Guard.Against.InvalidEmail(value);
            Value = value;
        }

        // Required for the ORM.
        private Email()
        {
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Email"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Email(string value) => new Email(value);

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Value;
    }
}
