using Dapper;
using Krafted.Framework.SharedKernel.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public static class EntityExtension
    {
        public static IList<string> GetColumnNames(this Entity entity, string tableName)
        {
            string pkName = $"{tableName}{typeof(Entity).GetProperty("Id").Name}";

            var columns = entity
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(p => p.Name)
                .ToList();

            columns.Insert(0, pkName);
            return columns;
        }

        public static DynamicParameters ToParams(this Entity entity, string tableName)
        {
            var pk = typeof(Entity).GetProperty("Id");
            string pkName = $"{tableName}{pk.Name}";
            object pkValue = pk.GetValue(entity);

            var param = entity
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(entity))).ToList();

            param.Insert(0, new KeyValuePair<string, object>(pkName, pkValue));

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(param);

            return parameters;
        }

        public static DynamicParameters ToParam(this Entity entity, string tableName)
        {
            var pkName = typeof(Entity).GetProperty("Id").Name;

            var parameters = new DynamicParameters();
            parameters.Add($"{tableName}{pkName}", entity.Id);

            return parameters;
        }
    }
}