using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("Krafted.DataAnnotations")]

namespace Krafted.Guards
{
    /// <summary>
    /// Provides a factory method to create a new instance of <see cref="Regex"/>.
    /// </summary>
    internal static class RegexFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Regex"/>.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that modify the regular expression.</param>
        /// <returns>A new instance of the <see cref="Regex"/>.</returns>
        internal static Regex NewRegex(string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture)
            => new(pattern, options, TimeSpan.FromSeconds(2.0));
    }
}
