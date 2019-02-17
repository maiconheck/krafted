using Flunt.Notifications;
using Flunt.Validations;

namespace Krafted.Framework.SharedKernel.Domain
{
    /// <summary>
    /// The money value object.
    /// </summary>
    /// <seealso cref="FluentValidator.Notifiable" />
    public class Money : Notifiable
    {
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
        public Money(decimal amount)
        {
            Amount = amount;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(IntegralPart, 0, nameof(Amount), "O saldo deve ser positivo."));
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets the integral part.
        /// </summary>
        /// <value>
        /// The integral part.
        /// </value>
        public int IntegralPart => (int)decimal.Truncate(Amount);

        public static implicit operator decimal(Money v) => v.Amount;

        public static explicit operator Money(decimal ammount) => new Money(ammount);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="m">The money.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Money operator +(Money m, decimal amount)
        {
            m.Amount += amount;

            return m;
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="m">The money.</param>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Money operator -(Money m, decimal amount)
        {
            m.Amount -= amount;

            return m;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => Amount.ToString("C");
    }
}