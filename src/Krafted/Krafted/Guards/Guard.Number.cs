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
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is less than <c>valueToCompare</c>,
        /// with this error message: Number cannot be less than {valueToCompare}.
        /// </summary>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard LessThan<T>(T number, T valueToCompare, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (valueToCompare.CompareTo(number) < 0)
                throw new ArgumentException(Texts.NumberCannotBeLessThan.Format(valueToCompare), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is greater than <c>valueToCompare</c>,
        /// with this error message: Number cannot be greater than {valueToCompare}.
        /// </summary>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard GreaterThan<T>(T number, T valueToCompare, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (valueToCompare.CompareTo(number) > 0)
                throw new ArgumentException(Texts.NumberCannotBeGreaterThan.Format(valueToCompare), parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is zero,
        /// with this error message: Number cannot be zero.
        /// </summary>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Zero<T>(T number, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (number.CompareTo(default(T)) == 0)
                throw new ArgumentException(Texts.NumberCannotBeZero, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is negative,
        /// with this error message: Number cannot be negative.
        /// </summary>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Negative<T>(T number, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (number.CompareTo(default(T)) < 0)
                throw new ArgumentException(Texts.NumberCannotBeNegative, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is positive,
        /// with this error message: Number cannot be positive.
        /// </summary>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Positive<T>(T number, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (number.CompareTo(default(T)) > 0)
                throw new ArgumentException(Texts.NumberCannotBePositive, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is zero or less than zero (i.e. negative),
        /// with this error message: 'The number cannot be zero.', if it is zero. Or 'The number cannot be negative.', if it is negative.
        /// </summary>
        /// <remarks>
        /// This method is equivalent to chain the <c>Zero(number).Negative(number)</c> methods.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard ZeroOrLess<T>(T number, string parameterName) where T : struct, IComparable
        {
            Guard.Against.NullOrWhiteSpace(parameterName, nameof(parameterName));

            Guard.Against.
                Zero(number, parameterName).
                Negative(number, parameterName);

            return this;
        }
    }
}
