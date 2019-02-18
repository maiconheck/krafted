using Flunt.Validations;
using Flunt.Notifications;

namespace SharedKernel.Domain
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, nameof(Address), "E-mail inválido."));
        }

        protected Email()
        {
        }

        public string Address { get; protected set; }

        public static explicit operator Email(string address) => new Email(address);

        public override string ToString()
        {
            return Address;
        }
    }
}