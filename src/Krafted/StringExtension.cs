using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// Provides extension methods to <see cref="string"/>.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Replace a string based on pattern.
        /// </summary>
        /// <param name="input">The input to be replaced.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the replacement
        /// string takes the place of each matched string. If pattern is not matched in the
        /// current instance, the method returns the current instance unchanged.
        /// </returns>
        public static string Replace(this string input, string pattern, string replacement) => Regex.Replace(input, pattern, replacement, RegexOptions.Compiled);

        /// <summary>
        /// Remove a string based on a pattern.
        /// </summary>
        /// <param name="input">The input where remove.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>
        /// A new string that is identical to the input string, except that the replacement
        /// string takes the place of each matched string. If pattern is not matched in the
        /// current instance, the method returns the current instance unchanged.
        /// </returns>
        public static string Remove(this string input, string pattern) => Replace(input, pattern, string.Empty);
    }
}