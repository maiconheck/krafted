using Flunt.Notifications;
using Flunt.Validations;

namespace Krafted.ValueObjects
{
    /// <summary>
    /// Represents an email value object.
    /// </summary>
    /// <seealso cref="Notifiable" />
    public class Email : Notifiable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, nameof(Address), Texts.InvalidEmail));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <remarks>ORM needs this constructor to materialize the entity.</remarks>
        protected Email()
        {
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; protected set; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Email"/>.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Email(string address) => new Email(address);

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString() => Address;
    }
}