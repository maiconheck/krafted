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
        /// Throws an <see cref="ArgumentException"/> if the specified <c>value</c> not exists in
        /// the specified <c>TEnum</c> enumeration, with this error message: The {value} not exists in the {TEnum}.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="value"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotExists<TEnum>(TEnum value, string message = "", [CallerArgumentExpression("value")] string? parameterName = null) where TEnum : Enum
        {
            var type = typeof(TEnum);

            if (!Enum.IsDefined(type, value))
                throw new ArgumentException(Texts.ValueNotExistsIn.Format(value, type.Name).OrFallback(message), parameterName);

            return this;
        }
    }
}
