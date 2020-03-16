using Flunt.Notifications;
using Flunt.Validations;
using Krafted.Data;

namespace Krafted.UnitTest.Krafted
{
    public class EntityDummy : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        public EntityDummy()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDummy"/> class.
        /// </summary>
        /// <param name="foo">The foo.</param>
        /// <param name="bar">The bar.</param>
        public EntityDummy(string foo, string bar = "")
        {
            Foo = foo;
            Bar = bar;

            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLengthIfNotNullOrEmpty(Foo, 5, nameof(Foo), "The foo must be a maximum of 5 characters.")
                    .HasMaxLengthIfNotNullOrEmpty(Bar, 10, nameof(Bar), "The bar must be a maximum of 10 characters."));
        }

        public string Foo { get; }

        public string Bar { get; }

        public new void AddNotificationsIfInvalid(params Notifiable[] notifications)
            => base.AddNotificationsIfInvalid(notifications);
    }
}