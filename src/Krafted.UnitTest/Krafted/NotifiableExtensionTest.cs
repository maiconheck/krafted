using System.Linq;
using Krafted.Test;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class NotifiableExtensionTest : XUnitTestBase
    {
        [Fact]
        public void Invalid_ValidAggregate_False()
        {
            var model = new DummyModel("Foo");
            Assert.False(model.Invalid());

            var model2 = new DummyModel("Foo", "Bar");
            Assert.False(model2.Invalid());
        }

        [Fact]
        public void Invalid_InvalidAggregate_True()
        {
            var model = new DummyModel("Foo......", "Bar................");
            Assert.True(model.Invalid());

            var model2 = new DummyModel("Foo", "Bar................");
            Assert.True(model2.Invalid());

            var model3 = new DummyModel("Foo......", "Bar");
            Assert.True(model3.Invalid());
        }

        [Fact]
        public void Notifications_ValidAggregate_Empty()
        {
            var model = new DummyModel("Foo");
            Assert.Empty(model.Notifications());

            var model2 = new DummyModel("Foo", "Bar");
            Assert.Empty(model2.Notifications());
        }

        [Fact]
        public void Notifications_InvalidAggregate_Notifications()
        {
            var model = new DummyModel("Foo......");
            Assert.Single(model.Notifications());
            Assert.Equal("The foo must be a maximum of 5 characters.", model.Notifications().First().Message);

            var model2 = new DummyModel("Foo.....", "Bar................");
            Assert.Equal(2, model2.Notifications().Count);
            Assert.Equal("The foo must be a maximum of 5 characters.", model2.Notifications().First().Message);
            Assert.Equal("The bar must be a maximum of 10 characters.", model2.Notifications().Last().Message);
        }
    }
}