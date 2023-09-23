using System.Globalization;

namespace Krafted.Guards
{
    /// <summary>
    /// Provides extension methods to <see cref="Guards"/>.
    /// </summary>
    internal static class StringExtensions
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

        /// <summary>
        /// Gets the error message provided in the <c>errorMessage</c> parameter, if it is not <c>null</c> nor empty; otherwise, fall-backs the localized error message provided in the <c>localizedMessage</c> parameter.
        /// </summary>
        /// <param name="localizedErrorMessage">The localized error message.</param>
        /// <param name="errorMessage">The error message to fall-back.</param>
        /// <returns>The error message, if the <c>errorMessage</c> parameter is not <c>null</c> nor empty; otherwise, the localized error message provided in the <c>localizedMessage</c> parameter.</returns>
        internal static string OrFallback(this string localizedErrorMessage, string errorMessage)
            => string.IsNullOrEmpty(errorMessage) ? localizedErrorMessage : errorMessage;
    }
}
