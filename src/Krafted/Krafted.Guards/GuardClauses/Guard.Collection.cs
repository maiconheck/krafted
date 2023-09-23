using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Throws an <see cref="ArgumentException"/> if the <c>collection</c> not contains any elements,
        /// with this error message: Collection cannot be empty.
        /// </summary>
        /// <remarks>
        /// If the <c>collection</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="collection">The parameter to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="collection"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotAny<T>(IEnumerable<T>? collection, string message = "", [CallerArgumentExpression("collection")] string? parameterName = null)
            => Validate<IEnumerable<T>?, ArgumentException>(collection, _ => !collection!.Any(), Texts.CollectionCannotBeEmpty, message, parameterName);

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>collection</c> contains any elements,
        /// with this error message: Collection should be empty.
        /// </summary>
        /// <remarks>
        /// If the <c>collection</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <see cref="ArgumentException"/>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <typeparam name="T">The type of enumerable.</typeparam>
        /// <param name="collection">The parameter to check.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="collection"/> corresponds. If you omit this parameter, the name of parameter is used.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Any<T>(IEnumerable<T>? collection, string message = "", [CallerArgumentExpression("collection")] string? parameterName = null)
            => Validate<IEnumerable<T>?, ArgumentException>(collection, _ => collection!.Any(), Texts.CollectionShouldBeEmpty, message, parameterName);
    }
}
