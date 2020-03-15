using System;

namespace Krafted.Data.SqlBuilder
{
    /// <summary>
    /// Provides an interface to a service that generate SQL data manipulation statements.
    /// The AbstractProduct participant [Gamma et al.].
    /// </summary>
    public interface ISqlBuilder
    {
        /// <summary>
        /// Generates a SELECT [all properies] FROM statement.
        /// </summary>
        /// <returns>A SELECT [all properies] FROM statement.</returns>
        string GetSelectCommand();

        /// <summary>
        /// Generates a SELECT [all properies] FROM WHERE Identifier = id statement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A SELECT [all properies] FROM WHERE Identifier = id statement.</returns>
        string GetSelectByIdCommand(Guid id);

        /// <summary>
        /// Generates an INSERT INTO statement.
        /// </summary>
        /// <returns>An INSERT INTO statement.</returns>
        string GetInsertCommand();

        /// <summary>
        /// Generates an UPDATE statement.
        /// </summary>
        /// <returns>An UPDATE statement.</returns>
        string GetUpdateCommand();

        /// <summary>
        /// Generates a DELETE FROM statement.
        /// </summary>
        /// <returns>A DELETE FROM statement.</returns>
        string GetDeleteCommand();
    }
}