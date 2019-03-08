using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    /// <summary>
    /// Provides services to generate SQL data manipulation statements.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public class SqlBuilder<TEntity>
        where TEntity : Entity
    {
        private readonly IDbConnection _connection;
        private readonly string _tableName;
        private readonly string _pkName;
        private readonly string _selectCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public SqlBuilder(IDbConnection connection)
        {
            _connection = connection;
            _tableName = typeof(TEntity).Name;
            _pkName = $"{_tableName}{typeof(TEntity).GetProperty("Id").Name}";

            var entity = (TEntity)FormatterServices.GetUninitializedObject(typeof(TEntity));
            _selectCommand = $"SELECT {string.Join(",", entity.GetColumnNames(_tableName))} FROM {_tableName}";
        }

        /// <summary>
        /// Generates a SELECT [all properies] FROM <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>SELECT [all properies] FROM <typeparamref name="TEntity"/> statement.</returns>
        public string GetSelectCommand() => _selectCommand;

        /// <summary>
        /// Generates a SELECT [all properies] FROM <typeparamref name="TEntity"/> WHERE Identifier = id statement.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The SELECT [all properies] FROM <typeparamref name="TEntity"/> WHERE Identifier = id statement.</returns>
        public string GetSelectByIdCommand(Guid id) => $"{_selectCommand} WHERE {_pkName} = '{id}'";

        /// <summary>
        /// Generates the INSERT INTO <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The INSERT INTO <typeparamref name="TEntity"/> statement.</returns>
        public string GetInsertCommand() => GetCommandBuilder(StatementType.Insert);

        /// <summary>
        /// Generates the UPDATE <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The UPDATE <typeparamref name="TEntity"/> statement.</returns>
        public string GetUpdateCommand() => GetCommandBuilder(StatementType.Update);

        /// <summary>
        /// Generates the DELETE FROM <typeparamref name="TEntity"/> statement.
        /// </summary>
        /// <returns>The DELETE FROM <typeparamref name="TEntity"/> statement.</returns>
        public string GetDeleteCommand() => GetCommandBuilder(StatementType.Delete);

        /// <summary>
        /// Generates the SQL statement based on the <see cref="StatementType"/>.
        /// </summary>
        /// <param name="type">The type of the statament.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">An <see cref="InvalidOperationException"/> that ocurs if <see cref="StatementType"/> has an invalid value.</exception>
        private string GetCommandBuilder(StatementType type)
        {
            using (var adapter = new SqlDataAdapter(_selectCommand, _connection.ConnectionString))
            using (var builder = new SqlCommandBuilder(adapter))
            {
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";

                const string pattern = @"(?<=SET).*?\,|(AND.*?\)\))|(?<=WHERE.)\(|(Original_)";

#pragma warning disable CC0019 // Use 'switch'
                if (type == StatementType.Insert)
                    return builder.GetInsertCommand(true).CommandText;
                else if (type == StatementType.Update)
                    return builder.GetUpdateCommand(true).CommandText.Remove(pattern);
                else if (type == StatementType.Delete)
                    return builder.GetDeleteCommand(true).CommandText.Remove(pattern);
                else
                    throw new InvalidOperationException();
#pragma warning restore CC0019 // Use 'switch'
            }
        }
    }
}