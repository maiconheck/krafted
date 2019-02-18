using System;
using System.Linq.Expressions;

namespace SharedKernel.Domain
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T model)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(model);
        }
    }
}