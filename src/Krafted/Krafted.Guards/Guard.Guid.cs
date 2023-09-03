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
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is empty,
        /// with this error message: Guid cannot be empty.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Empty(Guid parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (parameter.Equals(Guid.Empty))
                throw new ArgumentException(Texts.GuidCannotBeEmpty.OrFallback(message), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is not empty,
        /// with this error message: Guid should be empty.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotEmpty(Guid parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (!parameter.Equals(Guid.Empty))
                throw new ArgumentException(Texts.GuidShouldBeEmpty.OrFallback(message), parameterName);

            return this;
        }
    }
}
