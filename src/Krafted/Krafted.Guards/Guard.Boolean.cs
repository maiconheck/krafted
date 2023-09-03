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
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is <c>true</c>,
        /// with this error message: Parameter cannot be <c>true</c>.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard True(bool parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (parameter)
                throw new ArgumentException(Texts.ParameterCannotBeTrue.OrFallback(message), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>predicate</c> is <c>true</c>,
        /// with this error message: Predicate cannot be <c>true</c>.
        /// Or, if the optional parameter <c>message</c> was set, with their message.
        /// </summary>
        /// <param name="predicate">The predicate to check.</param>
        /// <param name="message">The optional error message passed to <see cref="ArgumentException"/> if the <c>predicate</c> is <c>true</c>.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard True(Predicate<bool> predicate, string message = "")
        {
            Guard.Against.Null(predicate, nameof(predicate));

            if (predicate.Invoke(true))
                throw new ArgumentException(Texts.PredicateCannotBeTrue.OrFallback(message));

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is <c>false</c>,
        /// with this error message: Parameter cannot be <c>false</c>.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard False(bool parameter, string parameterName, string message = "")
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (!parameter)
                throw new ArgumentException(Texts.ParameterCannotBeFalse.OrFallback(message), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>predicate</c> is <c>false</c>,
        /// with this error message: Predicate cannot be <c>false</c>.
        /// Or, if the optional parameter <c>message</c> was set, with their message.
        /// </summary>
        /// <param name="predicate">The predicate to check.</param>
        /// <param name="message">The optional error message passed to <see cref="ArgumentException"/> if the <c>predicate</c> is <c>false</c>.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard False(Predicate<bool> predicate, string message = "")
        {
            Guard.Against.Null(predicate, nameof(predicate));

            if (!predicate.Invoke(false))
                throw new ArgumentException(Texts.PredicateCannotBeFalse.OrFallback(message));

            return this;
        }
    }
}
