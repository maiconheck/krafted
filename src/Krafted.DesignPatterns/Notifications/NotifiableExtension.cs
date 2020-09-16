using System.Collections.Generic;
using System.Linq;

namespace Krafted.DesignPatterns.Notifications
{
    /// <summary>
    /// Provides extension methods to the <see cref="Notifiable"/>.
    /// </summary>
    public static class NotifiableExtension
    {
        /// <summary>
        /// Gets a value indicating whether all models of the models parameter are valid.
        /// </summary>
        /// <param name="models">The models to check.</param>
        /// <returns>
        ///   <c>true</c> if all models are valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool AllValid(this IEnumerable<Notifiable> models)
            => models.All(e => e.Valid);

        /// <summary>
        /// Gets a value indicating whether any model of the models parameter are invalid.
        /// </summary>
        /// <param name="models">The models to check.</param>
        /// <returns>
        ///   <c>true</c> if any models are invalid; otherwise, <c>false</c>.
        /// </returns>
        public static bool AnyInvalid(this IEnumerable<Notifiable> models)
            => models.Any(e => e.Invalid);
    }
}
