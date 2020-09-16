using System;

namespace Krafted.Guards
{
    /// <summary>
    /// Provides guard clauses to validate method arguments, in order to enforce defensive programming practice.
    /// <see href="https://en.wikipedia.org/wiki/Defensive_programming">See defensive programming</see>.
    /// <see href="http://wiki.c2.com/?GuardClause">See guard clauses</see>.
    /// </summary>
    public partial class Guard
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the parameter <c>false</c>,
        /// with this error message: Parameter cannot be <c>false</c>.
        /// </summary>
        /// <param name="param">The parameter to check.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard False(bool param, string paramName)
        {
            if (!param)
                throw new ArgumentException(Texts.InvalidEmailAddress, paramName);

            return this;
        }

        private static Regex CreateRegEx(string pattern)
        {
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            return new Regex(pattern, options, TimeSpan.FromSeconds(2.0));
        }
    }
}
