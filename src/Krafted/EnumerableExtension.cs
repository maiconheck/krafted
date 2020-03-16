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
        /// <param name="values">The value to find ind source.</param>
        /// <returns>True if all itens where found in source, otherwise false.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> values) => values.All(source.Contains);

        /// <summary>
        /// Returns the second element of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The second element in the specified sequence.</returns>
        public static T Second<T>(this IEnumerable<T> source) => source.ToArray()[1];

        /// <summary>
        /// Returns the third element of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The third element in the specified sequence.</returns>
        public static T Third<T>(this IEnumerable<T> source) => source.ToArray()[2];

        /// <summary>
        /// Returns the fourth element of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The fourth element in the specified sequence.</returns>
        public static T Fourth<T>(this IEnumerable<T> source) => source.ToArray()[3];

        /// <summary>
        /// Returns the fifth element of a sequence.
        /// </summary>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The fifth element in the specified sequence.</returns>
        public static T Fifth<T>(this IEnumerable<T> source) => source.ToArray()[4];
    }
}