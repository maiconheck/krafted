using System;
using System.Linq.Expressions;
using Krafted.DesignPatterns.Specifications;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Specifications
{
    public sealed class ModelStubSpecification : Specification<EntityDummy>
    {
        public override Expression<Func<EntityDummy, bool>> ToExpression()
            => m => m.Name == "Maicon" && m.Age == 35;
    }

    public sealed class ModelStubSpecification2 : Specification<EntityDummy>
    {
        public override Expression<Func<EntityDummy, bool>> ToExpression()
            => m => m.Enabled;
    }
}
