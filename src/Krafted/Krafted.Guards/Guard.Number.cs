using System;
using System.Runtime.CompilerServices;

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
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="valueToCompare"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard LessThan<T>(T? number, T valueToCompare, string message = "", [CallerArgumentExpression("valueToCompare")] string? parameterName = null) where T : struct, IComparable
            => Validate<T?, ArgumentException>(number, _ => valueToCompare.CompareTo(number) < 0, Texts.NumberCannotBeLessThan.Format(valueToCompare), message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is greater than <c>valueToCompare</c>,
        /// with this error message: Number cannot be greater than {valueToCompare}.
        /// </summary>
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="valueToCompare"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard GreaterThan<T>(T? number, T valueToCompare, string message = "", [CallerArgumentExpression("valueToCompare")] string? parameterName = null) where T : struct, IComparable
            => Validate<T?, ArgumentException>(number, _ => valueToCompare.CompareTo(number) > 0, Texts.NumberCannotBeGreaterThan.Format(valueToCompare), message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is negative,
        /// with this error message: Number cannot be negative.
        /// </summary>
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="number"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Negative<T>(T? number, string message = "", [CallerArgumentExpression("number")] string? parameterName = null) where T : struct, IComparable
            => Validate<T?, ArgumentException>(number, _ => number?.CompareTo(default(T)) < 0, Texts.NumberCannotBeNegative, message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is positive,
        /// with this error message: Number cannot be positive.
        /// </summary>
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="number"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Positive<T>(T? number, string message = "", [CallerArgumentExpression("number")] string? parameterName = null) where T : struct, IComparable
            => Validate<T?, ArgumentException>(number, _ => number?.CompareTo(default(T)) > 0, Texts.NumberCannotBePositive, message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is zero,
        /// with this error message: Number cannot be zero.
        /// </summary>
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="number"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Zero<T>(T? number, string message = "", [CallerArgumentExpression("number")] string? parameterName = null) where T : struct, IComparable
            => Validate<T?, ArgumentException>(number, _ => number?.CompareTo(default(T)) == 0, Texts.NumberCannotBeZero, message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>number</c> is zero or less than zero (i.e. negative),
        /// with this error message: 'The number cannot be zero.', if it is zero. Or 'The number cannot be negative.', if it is negative.
        /// <para>
        /// This method is equivalent to chain the <c>Zero(number).Negative(number)</c> methods.
        /// </para>
        /// </summary>
        /// <remarks>
        /// If the <c>number</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of the number.</typeparam>
        /// <param name="number">The number to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="number"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard ZeroOrLess<T>(T? number, string message = "", [CallerArgumentExpression("number")] string? parameterName = null) where T : struct, IComparable
        {
            if (number is null)
                return this;

            Guard.Against.NullOrWhiteSpace(parameterName);

            Guard.Against.
                Zero(number, message, parameterName).
                Negative(number, message, parameterName);

            return this;
        }
    }
}
