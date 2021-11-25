using System;
using System.Diagnostics.CodeAnalysis;
using Krafted.Guards;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an money value object.
    /// </summary>
    public sealed class Money : ValueObject<decimal>
    {
        private decimal _ammount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Money(decimal value)
        {
            Guard.Against.Negative(value, nameof(value));
            Value = value;
        }

        // Required for the ORM.
        [ExcludeFromCodeCoverage]
        private Money()
        {
        }

        /// <inheritdoc/>>
        public override decimal Value
        {
            get => _ammount;

            protected set
            {
                if (_ammount != value)
                {
                    Guard.Against.Negative(value, nameof(value));
                    _ammount = value;
                }
            }
        }

        /// <summary>
        /// Gets the integral part.
        /// </summary>
        /// <value>The integral part.</value>
        public int IntegralPart => (int)decimal.Truncate(Value);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Money"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator decimal(Money value)
        {
            Guard.Against
                .Null(value, nameof(value))
                .Negative(value.Value, nameof(value));

            return value.Value;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="decimal"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Money(decimal value) => new Money(value);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(Money money, decimal value)
        {
            Guard.Against
                .Null(money, nameof(money))
                .Negative(money.Value, nameof(money))
                .Negative(value, nameof(value));

            money.Value += value;

            return money;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(Money money, decimal value)
        {
            Guard.Against
                .Null(money, nameof(money))
                .Negative(money.Value, nameof(money))
                .Negative(value, nameof(value));

            money.Value -= value;

            Guard.Against.Negative(money.Value, nameof(money));

            return money;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new instance of the <see cref="Money"/> class.</returns>
        public static Money NewMoney(decimal value) => new Money(value);

        /// <summary>
        /// Returns the string representation of <see cref="Value"/> rounding to 2 decimal places.
        /// </summary>
        /// <remarks>
        ///   <example>
        ///   Examples:
        ///     <code>
        ///     decimal d = 0M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.0M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.00M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.01M; d.ToString() -> 0.01
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.1M; d.ToString() -> 0.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.10M; d.ToString() -> 0.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 00.1M; d.ToString() -> 0.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1M; d.ToString() -> 1.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1.1M; d.ToString() -> 1.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1.01M; d.ToString() -> 1.01
        ///     </code>
        ///   </example>
        /// </remarks>
        /// <returns>The the string representation of <see cref="Value"/>.</returns>
        public override string ToString() => Value.ToString("F2");

        /// <summary>
        /// Returns the string representation of <see cref="Value"/> rounding to 2 decimal places.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <remarks>
        ///   <example>
        ///   Examples:
        ///     <code>
        ///     decimal d = 0M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.0M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.00M; d.ToString() -> 0.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.01M; d.ToString() -> 0.01
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.1M; d.ToString() -> 0.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 0.10M; d.ToString() -> 0.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 00.1M; d.ToString() -> 00.01
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1M; d.ToString() -> 1.00
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1.1M; d.ToString() -> 1.10
        ///     </code>
        ///
        ///     <code>
        ///     decimal d = 1.01M; d.ToString() -> 1.01
        ///     </code>
        ///   </example>
        /// </remarks>
        /// <returns>The the string representation of <see cref="Value"/>.</returns>
        public override string ToString(IFormatProvider provider) => Value.ToString("F", provider);
    }
}
