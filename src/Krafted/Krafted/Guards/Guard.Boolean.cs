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
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard True(bool parameter, string parameterName)
        {
            if (parameter)
                throw new ArgumentException(Texts.ParameterCannotBeTrue, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>predicate</c> is <c>true</c>,
        /// with this error message: Predicate cannot be <c>true</c>.
        /// </summary>
        /// <param name="predicate">The predicate to check.</param>
        /// <param name="parameterName">Optional. The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard True(Predicate<bool> predicate, string parameterName = "")
        {
            Guard.Against.Null(predicate, nameof(predicate));

            if (predicate.Invoke(true))
            {
                if (string.IsNullOrWhiteSpace(parameterName))
                {
                    throw new ArgumentException(Texts.PredicateCannotBeTrue);
                }

                throw new ArgumentException(Texts.PredicateCannotBeTrue, parameterName);
            }

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is <c>false</c>,
        /// with this error message: Parameter cannot be <c>false</c>.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard False(bool parameter, string parameterName)
        {
            if (!parameter)
                throw new ArgumentException(Texts.ParameterCannotBeFalse, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>predicate</c> is <c>false</c>,
        /// with this error message: Predicate cannot be <c>false</c>.
        /// </summary>
        /// <param name="predicate">The predicate to check.</param>
        /// <param name="parameterName">Optional. The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard False(Predicate<bool> predicate, string parameterName = "")
        {
            Guard.Against.Null(predicate, nameof(predicate));

            if (!predicate.Invoke(false))
            {
                if (string.IsNullOrWhiteSpace(parameterName))
                {
                    throw new ArgumentException(Texts.PredicateCannotBeFalse);
                }

                throw new ArgumentException(Texts.PredicateCannotBeFalse, parameterName);
            }

            return this;
        }
    }
}
