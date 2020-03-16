using System;

namespace Krafted.Data
{
    /// <summary>
    /// Provides extension methods to <see cref="Entity"/>.
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// Sets the new identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public static void SetNewId(this Entity entity) => entity.Id = Guid.NewGuid();
    }
}