using Krafted.Guards;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides extension methods to <see cref="IList{T}"/>.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Moves an item from a specified old index to a specified new index.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        public static void Move<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            Guard.Against
                .NotAny(list)
                .Negative<int>(oldIndex)
                .Negative<int>(newIndex);

            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }
    }
}
