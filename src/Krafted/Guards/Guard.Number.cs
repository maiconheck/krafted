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
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is less than <c>valueToCompare</c>,
        /// with this error message: Parameter cannot be less than {valueToCompare}.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard LessThan<T>(T parameter, T valueToCompare, string parameterName) where T : struct, IComparable
        {
            Guard.Against.
                Null(parameter, nameof(parameter)).
                Null(valueToCompare, nameof(valueToCompare)).
                NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (valueToCompare.CompareTo(parameter) < 0)
                throw new ArgumentException(Texts.ParameterCannotBeLessThan.Format(valueToCompare), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is greater than <c>valueToCompare</c>,
        /// with this error message: Parameter cannot be greater than {valueToCompare}.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard GreaterThan<T>(T parameter, T valueToCompare, string parameterName) where T : struct, IComparable
        {
            Guard.Against.
                Null(parameter, nameof(parameter)).
                Null(valueToCompare, nameof(valueToCompare)).
                NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (valueToCompare.CompareTo(parameter) > 0)
                throw new ArgumentException(Texts.ParameterCannotBeGreaterThan.Format(valueToCompare), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>parameter</c> is equal zero,
        /// with this error message: Parameter cannot be equal 0.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Zero<T>(T parameter, string parameterName) where T : struct, IComparable
        {
            Guard.Against.
                Null(parameter, nameof(parameter)).
                NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (parameter.CompareTo(default(T)) == 0)
                throw new ArgumentException(Texts.ParameterCannotBeZero, parameterName);

            return this;
        }
    }
}
