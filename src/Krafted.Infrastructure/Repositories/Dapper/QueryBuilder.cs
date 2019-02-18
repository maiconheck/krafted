using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public class QueryBuilder<TEntity> where TEntity : Entity
    {
        private readonly IDbConnection _connection;
        private readonly string _tableName;
        private readonly string _pkName;
        private readonly string _selectCommand;

        public QueryBuilder(IDbConnection connection)
        {
            _connection = connection;
            _tableName = typeof(TEntity).Name;
            _pkName = $"{_tableName}{typeof(TEntity).GetProperty("Id").Name}";

            var entity = (TEntity)FormatterServices.GetUninitializedObject(typeof(TEntity));
            _selectCommand = $"SELECT {string.Join(",", entity.GetColumnNames(_tableName))} FROM {_tableName}";
        }

        public string GetSelectCommand() => _selectCommand;

        public string GetSelectByIdCommand(Guid id) => $"{_selectCommand} WHERE {_pkName} = '{id}'";

        public string GetInsertCommand() => GetCommandBuilder(StatementType.Insert);

        public string GetUpdateCommand() => GetCommandBuilder(StatementType.Update);

        public string GetDeleteCommand() => GetCommandBuilder(StatementType.Delete);

        private string GetCommandBuilder(StatementType type)
        {
            using (var adapter = new SqlDataAdapter(_selectCommand, _connection.ConnectionString))
            {
                using (var builder = new SqlCommandBuilder(adapter))
                {
                    builder.QuotePrefix = "[";
                    builder.QuoteSuffix = "]";

                    const string pattern = @"(?<=SET).*?\,|(AND.*?\)\))|(?<=WHERE.)\(|(Original_)";

                    if (type == StatementType.Insert)
                        return builder.GetInsertCommand(true).CommandText;
                    else if (type == StatementType.Update)
                        return builder.GetUpdateCommand(true).CommandText.Remove(pattern);
                    else if (type == StatementType.Delete)
                        return builder.GetDeleteCommand(true).CommandText.Remove(pattern);
                    else
                        throw new InvalidOperationException();
                }
            }
        }
    }
}