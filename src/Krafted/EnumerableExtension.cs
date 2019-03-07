using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumerableExtension
    {
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> values) => values.All(source.Contains);
    }
}
