using System.Globalization;
using System.Linq;
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
        public static string Format(this string input, params object[] args)
            => string.Format(CultureInfo.InvariantCulture, input, args);

        /// <summary>
        /// Transform an specified PascalCase string to an Snake_Case string (that is. underscore separation).
        /// </summary>
        /// <param name="input">A PascalCase string to be transformed to an Snake_Case string.</param>
        /// <example>
        /// <code>
        /// "MyPascalCaseString.PascalCaseToSnakeCase()" // My_Camel_Case_String
        /// </code>
        /// </example>
        /// <returns>
        /// The PascalCase string transformed to an Snake_Case string (that is. underscore separation).
        /// </returns>
        public static string PascalCaseToSnakeCase(this string input)
            => string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
    }
}
