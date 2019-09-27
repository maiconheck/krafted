using System.Data;

namespace Krafted.Infrastructure.Sql
{
    /// <summary>
    /// The AbstractFactory participant [Gamma et al.].
    /// </summary>
    public interface ISqlBuilderFactory
    {
        /// <summary>
        /// Create a SqlBuilder.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The SqlBuilder.</returns>
        ISqlBuilder NewSqlBuilder<TEntity>(IDbConnection connection)
            where TEntity : Entity;
    }
}