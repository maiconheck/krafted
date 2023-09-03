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
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the length of the <c>parameter</c> is different of the specified <c>exactLength</c>,
        /// with this error message: <c>parameterName</c> must be length <c>exactLength</c>.
        /// </summary>
        /// <remarks>If the parameter is null or empty, no exception will be thrown.</remarks>
        /// <param name="exactLength">The exact length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentOutOfRangeException">.</exception>
        public Guard Length(uint exactLength, string parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (string.IsNullOrEmpty(parameter))
                return this;

            if (parameter.Length != exactLength)
                throw new ArgumentOutOfRangeException(parameterName, Texts.ParameterMustBeExactLength.Format(parameterName, exactLength).OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the length of the <c>parameter</c> is outside of the specified range,
        /// with this error message: <c>parameterName</c> must be at least <c>minLength</c> character, and at most <c>maxLength</c> characters.
        /// </summary>
        /// <remarks>If the parameter is null or empty, no exception will be thrown.</remarks>
        /// <param name="minLength">The minimum length the parameter must be.</param>
        /// <param name="maxLength">The maximum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentOutOfRangeException">.</exception>
        public Guard Length(uint minLength, uint maxLength, string parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (string.IsNullOrEmpty(parameter))
                return this;

            if (parameter.Length < minLength || parameter.Length > maxLength)
                throw new ArgumentOutOfRangeException(parameterName, Texts.ParameterMustBeInsideRangeLength.Format(parameterName, minLength, maxLength).OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is greater than the specified <c>maxLength</c>,
        /// with this error message: <c>parameterName</c> must be at most <c>maxLength</c> characters.
        /// </summary>
        /// <remarks>If the parameter is null or empty, no exception will be thrown.</remarks>
        /// <param name="maxLength">The maximum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard MaxLength(uint maxLength, string parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (string.IsNullOrEmpty(parameter))
                return this;

            if (parameter.Length > maxLength)
                throw new ArgumentException(Texts.ParameterMustBeAtMostLength.Format(parameterName, maxLength).OrFallback(message), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is less than the specified <c>minLength</c>,
        /// with this error message: <c>parameterName</c> must be at least <c>minLength</c> characters.
        /// </summary>
        /// <remarks>If the parameter is null or empty, no exception will be thrown.</remarks>
        /// <param name="minLength">The minimum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard MinLength(uint minLength, string parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (string.IsNullOrEmpty(parameter))
                return this;

            if (parameter.Length < minLength)
                throw new ArgumentException(Texts.ParameterMustBeAtLeastLength.Format(parameterName, minLength).OrFallback(message), parameterName);

            return this;
        }
    }
}
