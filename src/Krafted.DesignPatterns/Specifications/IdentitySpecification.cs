using System;
using System.Linq.Expressions;

namespace Krafted.DesignPatterns.Specifications
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression() => x => true;
    }
}
