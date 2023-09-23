using System;
using System.Runtime.CompilerServices;
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
        /// <remarks>
        /// If the <c>parameter</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="parameter"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Match(string? parameter, string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "", [CallerArgumentExpression("parameter")] string? parameterName = null)
            => ValidateRegex<ArgumentException>(parameter, pattern, parameterName!, options, mustMatch: false, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// finds a match in <c>parameter</c>,
        /// with this error message: Parameter matches the specified regular expression.
        /// </summary>
        /// <remarks>
        /// If the <c>parameter</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <c>TException</c>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="parameter"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Match<TException>(string? parameter, string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "", [CallerArgumentExpression("parameter")] string? parameterName = null) where TException : Exception
            => ValidateRegex<TException>(parameter, pattern, parameterName!, options, mustMatch: false, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// not finds a match in <c>parameter</c>,
        /// with this error message: Parameter not matches the specified regular expression.
        /// </summary>
        /// <remarks>
        /// If the <c>parameter</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="parameter"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotMatch(string? parameter, string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "", [CallerArgumentExpression("parameter")] string? parameterName = null)
            => ValidateRegex<ArgumentException>(parameter, pattern, parameterName!, options, mustMatch: true, message);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the regular expression specified in <c>pattern</c>
        /// not finds a match in <c>parameter</c>,
        /// with this error message: Parameter not matches the specified regular expression.
        /// </summary>
        /// <remarks>
        /// If the <c>parameter</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <c>TException</c>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="options">The regular expression options.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="parameter"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotMatch<TException>(string? parameter, string pattern, RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase, string message = "", [CallerArgumentExpression("parameter")] string? parameterName = null) where TException : Exception
            => ValidateRegex<TException>(parameter, pattern, parameterName!, options, mustMatch: true, message);

        private Guard ValidateRegex<TException>(string? parameter, string pattern, string parameterName, RegexOptions options, bool mustMatch, string message)
            where TException : Exception
        {
            if (parameter is null)
                return this;

            var regEx = Validator.NewRegEx(pattern, options);
            string errorMessage = mustMatch ? Texts.ParameterNotMatchesRegEx : Texts.ParameterMatchesRegEx;

            return Validate<string?, TException>(parameter, _ => regEx.IsMatch(parameter) != mustMatch, errorMessage, message, parameterName);
        }
    }
}
