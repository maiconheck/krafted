using System;
using System.Text.RegularExpressions;

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
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// finds a match in <c>parameter</c>,
        /// with this error message: Parameter matches the specified regular expression.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Match(string parameter, string pattern, string parameterName, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "")
        => Validate<ArgumentException>(parameter, pattern, parameterName, options, mustMatch: false, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// finds a match in <c>parameter</c>,
        /// with this error message: Parameter matches the specified regular expression.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Match<TException>(string parameter, string pattern, string parameterName, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "")
            where TException : Exception
            => Validate<TException>(parameter, pattern, parameterName, options, mustMatch: false, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// not finds a match in <c>parameter</c>,
        /// with this error message: Parameter not matches the specified regular expression.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotMatch(string parameter, string pattern, string parameterName, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "")
            => Validate<ArgumentException>(parameter, pattern, parameterName, options, mustMatch: true, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// not finds a match in <c>parameter</c>,
        /// with this error message: Parameter not matches the specified regular expression.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotMatch<TException>(string parameter, string pattern, string parameterName, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "")
            where TException : Exception
            => Validate<TException>(parameter, pattern, parameterName, options, mustMatch: true, message);

        private Guard Validate<TException>(string parameter, string pattern, string parameterName, RegexOptions options, bool mustMatch, string message)
            where TException : Exception
        {
            Guard.Against
                .NullOrWhiteSpace(parameterName, nameof(parameterName))
                .Null(parameter, parameterName);

            var regEx = Validator.NewRegEx(pattern, options);

            string errorMessage = mustMatch ? Texts.ParameterNotMatchesRegEx : Texts.ParameterMatchesRegEx;

            if (regEx.IsMatch(parameter) != mustMatch)
                throw ExceptionFactory.NewException<TException>(errorMessage.OrFallback(message), parameterName);

            return this;
        }
    }
}
