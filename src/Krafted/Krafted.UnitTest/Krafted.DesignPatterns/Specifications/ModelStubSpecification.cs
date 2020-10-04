using System;
using System.Linq.Expressions;
using Krafted.DesignPatterns.Specifications;
using Krafted.UnitTest.Krafted.DesignPatterns.Notifications;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Specifications
{
    public sealed class ModelStubSpecification : Specification<ModelStub>
    {
        public override Expression<Func<ModelStub, bool>> ToExpression()
            => m => m.Name == "Maicon" && m.Age == 35;
    }
}
