using System.Linq;
using Krafted.DesignPatterns.Notifications;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class NotifiableExtensionTest
    {
        [Fact]
        public void Invalid_ValidAggregate_False()
        {
            var model = new EntityDummy("Foo");
            Assert.False(model.Invalid());

            var model2 = new EntityDummy("Foo", "Bar");
            Assert.False(model2.Invalid());
        }

        [Theory]
        [InlineData("Foo......", "Bar................")]
        [InlineData("Foo", "Bar................")]
        [InlineData("Foo......", "Bar")]
        public void Invalid_InvalidAggregate_True(string foo, string bar)
        {
            var model = new EntityDummy(foo, bar);
            Assert.True(model.Invalid());
        }

        [Fact]
        public void Notifications_ValidAggregate_Empty()
        {
            var model = new EntityDummy("Foo");
            Assert.Empty(model.Notifications());

            var model2 = new EntityDummy("Foo", "Bar");
            Assert.Empty(model2.Notifications());
        }

        [Fact]
        public void Notifications_InvalidAggregate_Notifications()
        {
            var model = new EntityDummy("Foo......");
            Assert.Single(model.Notifications());
            Assert.Equal("The foo must be a maximum of 5 characters.", model.Notifications().First().Message);

            var model2 = new EntityDummy("Foo.....", "Bar................");
            Assert.Equal(2, model2.Notifications().Count);
            Assert.Equal("The foo must be a maximum of 5 characters.", model2.Notifications().First().Message);
            Assert.Equal("The bar must be a maximum of 10 characters.", model2.Notifications().Last().Message);
        }
    }
}