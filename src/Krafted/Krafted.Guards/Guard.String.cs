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
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is outside of the specified <c>exactLength</c>,
        /// with this error message: <c>parameterName</c> must be length <c>exactLength</c>.
        /// </summary>
        /// <param name="exactLength">The exact length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Length(uint exactLength, string parameter, string parameterName)
        {
            Guard.Against.Null(parameter, nameof(parameterName));

            if (parameter.Length != exactLength)
                throw new ArgumentException(Texts.ParameterMustBeExactLength.Format(parameterName, exactLength), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is outside of the specified range,
        /// with this error message: <c>parameterName</c> must be at least <c>minLength</c> character, and at most <c>maxLength</c> characters.
        /// </summary>
        /// <param name="minLength">The minimum length the parameter must be.</param>
        /// <param name="maxLength">The maximum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Length(uint minLength, uint maxLength, string parameter, string parameterName)
        {
            Guard.Against.Null(parameter, nameof(parameterName));

            if (parameter.Length < minLength || parameter.Length > maxLength)
                throw new ArgumentException(Texts.ParameterMustBeInsideRangeLength.Format(parameterName, minLength, maxLength), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is greater than the specified <c>maxLength</c>,
        /// with this error message: <c>parameterName</c> must be at most <c>maxLength</c> characters.
        /// </summary>
        /// <param name="maxLength">The maximum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard MaxLength(uint maxLength, string parameter, string parameterName)
        {
            Guard.Against.Null(parameter, nameof(parameterName));

            if (parameter.Length > maxLength)
                throw new ArgumentException(Texts.ParameterMustBeAtMostLength.Format(parameterName, maxLength), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the length of the <c>parameter</c> is less than the specified <c>minLength</c>,
        /// with this error message: <c>parameterName</c> must be at least <c>minLength</c> characters.
        /// </summary>
        /// <param name="minLength">The minimum length the parameter must be.</param>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard MinLength(uint minLength, string parameter, string parameterName)
        {
            Guard.Against.Null(parameter, nameof(parameterName));

            if (parameter.Length < minLength)
                throw new ArgumentException(Texts.ParameterMustBeAtLeastLength.Format(parameterName, minLength), parameterName);

            return this;
        }
    }
}
