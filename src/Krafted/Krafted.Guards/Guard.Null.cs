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
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null,
        /// with this error message: Parameter cannot be null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        /// <returns>The guard.</returns>
        public Guard Null<T>(T parameter, string parameterName, string message = "") where T : class
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (parameter is null)
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNull.OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null or an empty string,
        /// with this error message: Parameter cannot be null or empty.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        public Guard NullOrEmpty(string parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNullOrEmpty.OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null, an empty string or consists only of white-space,
        /// with this error message: Parameter cannot be null, empty or consists exclusively of white-space characters.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameter"/> is empty, or consists only of white-space.</exception>
        public Guard NullOrWhiteSpace(string parameter, string parameterName, string message = "")
        {
            if (string.IsNullOrWhiteSpace(parameterName))
                throw new ArgumentNullException(nameof(parameterName), Texts.ParameterCannotBeNullEmptyOrWhiteSpace);

            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNullEmptyOrWhiteSpace.OrFallback(message));

            return this;
        }
    }
}
