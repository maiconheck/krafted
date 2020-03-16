using Krafted.Data;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class SpecificationTest
    {
        [Theory]
        [InlineData("foo!")]
        [InlineData("bar!")]
        public void IsSatisfiedBy_ValidValue_True(string value)
        {
            var model = new EntityDummy(value);
            model.SetNewId();

            Assert.True(EntityDummySpec.Default.IsSatisfiedBy(model));
        }

        [Theory]
        [InlineData("FOO!")]
        [InlineData("BAR!")]
        [InlineData("")]
        public void IsSatisfiedBy_InvalidValue_False(string value)
        {
            var model = new EntityDummy(value);
            model.SetNewId();

            Assert.False(EntityDummySpec.Default.IsSatisfiedBy(model));
        }
    }
}