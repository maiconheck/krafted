using Krafted.DesignPatterns.Specifications;
using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Specifications
{
    [Trait(nameof(UnitTest), "Krafted.DesignPatterns")]
    public class SpecificationTest
    {
        [Fact]
        public void Spec_IsSatisfiedByModel_True()
        {
            var model1 = new ModelStub(35, "Maicon", true);
            var spec1 = Specification<ModelStub>.All
                .And(new ModelStubSpecification())
                .And(new ModelStubSpecification2());

            Assert.True(spec1.IsSatisfiedBy(model1));

            var model2 = new ModelStub(35, "Maicon", false);
            var spec2 = Specification<ModelStub>.All
                .And(new ModelStubSpecification())
                .Or(new ModelStubSpecification2());

            Assert.True(spec2.IsSatisfiedBy(model2));
        }

        [Fact]
        public void Spec_IsSatisfiedByModel_False()
        {
            var model1 = new ModelStub(34, "Maicon");
            var spec1 = new ModelStubSpecification();

            Assert.False(spec1.IsSatisfiedBy(model1));

            var model2 = new ModelStub(35, "Maicon", false);
            var spec2 = Specification<ModelStub>.All.Not();

            Assert.False(spec2.IsSatisfiedBy(model2));
        }
    }
}
