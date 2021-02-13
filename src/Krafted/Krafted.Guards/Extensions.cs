using System.Globalization;

namespace Krafted.Guards
{
    /// <summary>
    /// Provides extension methods to <see cref="Guards"/>.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Replaces the format items in a string with the string representations of corresponding
        /// objects in a specified array. A parameter supplies culture-specific formatting
        /// information.
        /// </summary>
        /// <param name="input">A composite string to be formated.</param>
        /// <param name="args">An object array that contains objects to format the <c>value</c>.</param>
        /// <returns>
        /// A copy of format in which the format items have been replaced by the string representation
        /// of the corresponding objects in args.
        /// </returns>
        internal static string Format(this string input, params object[] args)
            => string.Format(CultureInfo.InvariantCulture, input, args);
    }
}
