using System;
using System.Data;

namespace Krafted.Data.SqlBuilder
{
    /// <summary>
    /// Represents a Factory Method [Gamma et al.] to the <see cref="ISqlBuilder"/>.
    /// </summary>
    public static class SqlBuilderFactory
    {
        /// <summary>
        /// Create a SqlBuilder.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <typeparam name="TSqlBuilderFactory">The type of the ConcreteFactory [Gamma et al.].</typeparam>
        /// <param name="connection">The connection.</param>
        /// <returns>The SqlBuilder, a.k.a. ConcreteProduct [Gamma et al.].</returns>
        public static ISqlBuilder NewSqlBuilder<TEntity, TSqlBuilderFactory>(IDbConnection connection)
            where TEntity : Entity
            where TSqlBuilderFactory : ISqlBuilderFactory
        {
            GuardAgainst.Null(connection, nameof(connection));

            var factory = (TSqlBuilderFactory)Activator.CreateInstance(typeof(TSqlBuilderFactory));
            return factory.NewSqlBuilder<TEntity>(connection);
        }
    }
}
