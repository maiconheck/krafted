using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Provides extension methods to <see cref="string"/>.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// In a specified input string, replaces all strings that match a specified regular
        /// expression with a specified replacement string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the replacement
        /// string takes the place of each matched string. If pattern is not matched in the
        /// current instance, the method returns the current instance unchanged.
        /// </returns>
        public static string Replace(this string input, string pattern, string replacement, RegexOptions options)
            => Regex.Replace(input, pattern, replacement, options);

        /// <summary>
        /// In a specified input string, removes all strings that match a specified regular
        /// expression with a specified replacement string.
        /// </summary>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the empty
        /// string takes the place of each matched string. If pattern is not matched in the
        /// current instance, the method returns the current instance unchanged.
        /// </returns>
        public static string Remove(this string input, string pattern) => Replace(input, pattern, string.Empty, RegexOptions.Compiled);
    }
}