using Krafted.DesignPatterns.Ddd;
using Krafted.Guards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krafted.EntityFrameworkCore.Mapping
{
    /// <summary>
    /// Provides the common configurations for the table mapping.
    /// </summary>
    public static class MapExtension
    {
        /// <summary>
        /// Configures entity with the default options.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="tableName">The name of the table.</param>
        public static void HasMappingDefault<T>(this EntityTypeBuilder<T> builder, string tableName) where T : Entity
        {
            Guard.Against.NullOrWhiteSpace(tableName, nameof(tableName));

            string keyName = $"{tableName}Id";

            builder.ToTable(tableName);

            builder.HasKey(p => p.Id)
                   .HasName(keyName);

            builder.Property(p => p.Id)
                   .HasColumnName(keyName);
        }
    }
}
