using System;
using System.Diagnostics.CodeAnalysis;
using Krafted.Guards;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an URL (Uniform Resource Locator) value object.
    /// </summary>
    public sealed class Url : ValueObject<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Url(string value)
        {
            Guard.Against.NullOrWhiteSpace(value);

            var regEx = Validator.NewRegEx(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})");

            if (!regEx.IsMatch(value))
                throw new FormatException(Texts.InvalidUrl.Format(value));

            Value = value;
        }

        // Required for the ORM.
        [ExcludeFromCodeCoverage]
        private Url()
        {
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Url"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Url(string value) => new Url(value);

        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="Url"/> class.</returns>
        public static Url NewUrl(string value) => new Url(value);
    }
}
