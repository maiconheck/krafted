using System.Collections.Generic;
using System.Globalization;
using Krafted.DesignPatterns.Ddd;
using Krafted.Guards;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an money value object.
    /// </summary>
    public sealed class Money : ValueObject, IValueObject<decimal>
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
        private Money()
        {
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value
        {
            get => _ammount;

            private set
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
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Value.ToString("C", CultureInfo.CurrentCulture);

        /// <summary>
        /// Gets the equality components to make the comparison, since a value object must not be based on identity.
        /// </summary>
        /// <returns>
        /// The equality components.
        /// </returns>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
