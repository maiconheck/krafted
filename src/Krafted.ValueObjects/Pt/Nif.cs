using Krafted.Guards;

namespace Krafted.ValueObjects.Pt
{
    public class Nif : IValueObject<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nif"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Nif(string value)
        {
            Guard.Against.InvalidNif(value);
            Value = value;
        }

        // Required for the ORM.
        private Nif()
        {
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Nif"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(Nif value)
        {
            Guard.Against.InvalidNif(value);
            return value.Value;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Nif"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Nif(string value) => new Nif(value);

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Value;
    }
}
