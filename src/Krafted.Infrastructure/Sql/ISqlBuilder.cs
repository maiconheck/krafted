using System;

namespace Krafted.Infrastructure.Sql
{
    /// <summary>
    /// Provides an interface to a service that generate SQL data manipulation statements.
    /// The AbstractProduct participant [Gamma et al.]
    /// </summary>
    public interface ISqlBuilder
    {
        /// <summary>
        /// Generates a SELECT [all properies] FROM <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>SELECT [all properies] FROM <typeparamref name="TEntity"/> statement.</returns>
        string GetSelectCommand();

        /// <summary>
        /// Generates a SELECT [all properies] FROM <typeparamref name="TEntity"/> WHERE Identifier = id statement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The SELECT [all properies] FROM <typeparamref name="TEntity"/> WHERE Identifier = id statement.</returns>
        string GetSelectByIdCommand(Guid id);

        /// <summary>
        /// Generates the INSERT INTO <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The INSERT INTO <typeparamref name="TEntity"/> statement.</returns>
        string GetInsertCommand();

        /// <summary>
        /// Generates the UPDATE <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The UPDATE <typeparamref name="TEntity"/> statement.</returns>
        string GetUpdateCommand();

        /// <summary>
        /// Generates the DELETE FROM <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The DELETE FROM <typeparamref name="TEntity"/> statement.</returns>
        string GetDeleteCommand();
    }
}