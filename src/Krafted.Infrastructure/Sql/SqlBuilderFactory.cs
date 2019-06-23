using System.Data;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Sql
{
    /// <summary>
    /// Represents a Factory Method [Gamma et al.] to the ISqlBuilder.
    /// </summary>
    public static class SqlBuilderFactory
    {
        /// <summary>
        /// Create a SqlBuilder.
        /// </summary>
        /// <param name="factory">The SqlBuilder abstract factory.</param>
        /// <param name="connection">The connection.</param>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The concrete SqlBuilder.</returns>
        public static ISqlBuilder NewSqlBuilder<TEntity>(ISqlBuilderFactory factory, IDbConnection connection)
            where TEntity : Entity
                => factory.NewSqlBuilder<TEntity>(connection);
    }
}