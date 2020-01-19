using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Flunt.Notifications;

namespace Krafted
{
    /// <summary>
    /// Provides extension methods to <see cref="Notifiable"/>.
    /// </summary>
    public static class NotifiableExtension
    {
        /// <summary>
        /// Gets a value indicating whether any aggregate models are invalid (contain any notifications).
        /// </summary>
        /// <param name="aggregate">The model.</param>
        /// <returns><c>false</c> if any model is invalid; otherwise, <c>true</c>.</returns>
        public static bool Invalid(this Notifiable aggregate)
            => GetModels(aggregate).Any(n => n.Invalid);

        /// <summary>
        /// Gets a list containing all notifications of all models of the aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        /// <returns>A list containing all notifications of all models of the aggregate.</returns>
        public static List<Notification> Notifications(this Notifiable aggregate)
            => GetModels(aggregate).SelectMany(m => m.Notifications).ToList();

        private static IEnumerable<Notifiable> GetModels(Notifiable aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            var models = aggregate
                .GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(p => typeof(Notifiable).IsAssignableFrom(p.PropertyType))
                .Select(p => (Notifiable)p.GetValue(aggregate))
                .ToList();

            models.Insert(0, aggregate);

            return models;
        }
    }
}