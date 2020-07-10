using System;
using System.Linq;
using System.Linq.Expressions;

namespace Krafted.DesignPatterns.Specifications
{
    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        public NotSpecification(Specification<T> specification)
            => _specification = specification;

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> expression = _specification.ToExpression();
            UnaryExpression notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}
