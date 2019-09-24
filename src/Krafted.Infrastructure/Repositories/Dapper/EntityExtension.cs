﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    /// <summary>
    /// Provides extension methods to <see cref="Entity"/>.
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="tableName">The name of the table.</param>
        /// <returns>The column names.</returns>
        public static IList<string> GetColumnNames(this Entity entity, string tableName)
        {
            entity.ThrowIfNull(nameof(entity));

            var pkName = $"{tableName}{typeof(Entity).GetProperty("Id").Name}";

            var columns = entity
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(p => p.Name)
                .ToList();

            columns.Insert(0, pkName);
            return columns;
        }

        /// <summary>
        /// Converts the properties of the entity to an <see cref="DynamicParameters" /> object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>The converted parameters.</returns>
        public static DynamicParameters ToParams(this Entity entity, string tableName)
        {
            entity.ThrowIfNull(nameof(entity));
            tableName.ThrowIfNullOrWhiteSpace(nameof(tableName));

            var pk = typeof(Entity).GetProperty("Id");
            var pkName = $"{tableName}{pk.Name}";
            var pkValue = pk.GetValue(entity);

            var param = entity
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(entity))).ToList();

            param.Insert(0, new KeyValuePair<string, object>(pkName, pkValue));

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(param);

            return parameters;
        }

        /// <summary>
        /// Converts the properties of the entity to an <see cref="DynamicParameters" /> object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>The converted parameters.</returns>
        public static DynamicParameters ToParam(this Entity entity, string tableName)
        {
            entity.ThrowIfNull(nameof(entity));
            tableName.ThrowIfNullOrWhiteSpace(nameof(tableName));

            var pkName = typeof(Entity).GetProperty("Id").Name;

            var parameters = new DynamicParameters();
            parameters.Add($"{tableName}{pkName}", entity.Id);

            return parameters;
        }
    }
}