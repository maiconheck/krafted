using Krafted.UnitTest.Krafted.DesignPatterns.Notifications;
using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Specifications
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class SpecificationTest
    {
        [Fact]
        public void Spec_IsSatisfiedByModel_True()
        {
            var model = new ModelStub(35, "Maicon");
            var spec = new ModelStubSpecification();

            Assert.True(spec.IsSatisfiedBy(model));
        }

        [Fact]
        public void Spec_IsSatisfiedByModel_False()
        {
            var model = new ModelStub(34, "Maicon");

            var spec = new ModelStubSpecification();
            spec.And(spec);

            Assert.False(spec.IsSatisfiedBy(model));
        }
    }
}
