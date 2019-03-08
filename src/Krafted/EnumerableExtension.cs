using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides extension methods to <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// Verifies if the enumerable contains all the values.
        /// </summary>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="source">The source where find.</param>
        /// <param name="values">The value to to find ind source.</param>
        /// <returns>True if all itens where found in source, otherwise false.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> values) => values.All(source.Contains);
    }
}