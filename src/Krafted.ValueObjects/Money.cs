using System.Globalization;
using Flunt.Notifications;
using Flunt.Validations;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// The money value object.
    /// </summary>
    /// <seealso cref="Notifiable" />
    public class Money : Notifiable
    {
        private decimal _ammount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        public Money()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        public Money(decimal amount) => Amount = amount;

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount
        {
            get => _ammount;

            private set
            {
                if (_ammount != value)
                {
                    _ammount = value;
                    Validate();
                }
            }
        }

        /// <summary>
        /// Gets the integral part.
        /// </summary>
        /// <value>The integral part.</value>
        public int IntegralPart => (int)decimal.Truncate(Amount);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Money"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator decimal(Money value)
        {
            ExceptionHelper.ThrowIfNull(() => value);
            return value.Amount;
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="decimal"/> to <see cref="Money"/>.
        /// </summary>
        /// <param name="ammount">The ammount.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Money(decimal ammount) => new Money(ammount);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="m">The money.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator +(Money m, decimal amount)
        {
            ExceptionHelper.ThrowIfNull(() => m);

            m.Amount += amount;
            return m;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="m">The money.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>The result of the operator.</returns>
        public static Money operator -(Money m, decimal amount)
        {
            ExceptionHelper.ThrowIfNull(() => m);

            m.Amount -= amount;
            return m;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Amount.ToString("C", CultureInfo.CurrentCulture);

        private void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Amount, 0, nameof(Amount), Texts.BalanceMustBePositive));
        }
    }
}