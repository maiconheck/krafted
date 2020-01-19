using Flunt.Validations;

namespace Krafted.UnitTest.Krafted
{
    public class DummyModel : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DummyModel"/> class.
        /// </summary>
        /// <param name="foo">The foo.</param>
        /// <param name="bar">The bar.</param>
        public DummyModel(string foo, string bar = "")
        {
            Foo = foo;
            Bar = bar;

            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMaxLengthIfNotNullOrEmpty(Foo, 5, nameof(Foo), "The foo must be a maximum of 5 characters.")
                    .HasMaxLengthIfNotNullOrEmpty(Bar, 10, nameof(Bar), "The bar must be a maximum of 10 characters."));
        }

        public string Foo { get; set; }

        public string Bar { get; set; }
    }
}