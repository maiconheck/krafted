using System;
using System.Linq.Expressions;

namespace Krafted.UnitTest.Krafted
{
    public sealed class EntityDummySpec : Specification<EntityDummy>
    {
        public static readonly EntityDummySpec Default = new EntityDummySpec();

        private EntityDummySpec()
        {
        }

        public override Expression<Func<EntityDummy, bool>> ToExpression()
            => x => (x.Foo.Equals("foo!", StringComparison.Ordinal) || x.Foo.Equals("bar!", StringComparison.Ordinal));
    }
}