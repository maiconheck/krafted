using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtension
    {
        public static string Replace(this string input, string pattern, string replacement) =>
            Regex.Replace(input, pattern, replacement, RegexOptions.Compiled);

        public static string Remove(this string input, string pattern) =>
            Replace(input, pattern, string.Empty);
    }
}