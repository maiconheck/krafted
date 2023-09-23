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
        private Guard()
        {
        }

        /// <summary>
        /// The entry point to build the guard clauses.
        /// </summary>
        public static Guard Against => new();

        /// <summary>
        /// <para>
        /// Throws an <c>TException</c> if the <c>predicate</c> is satisfied, with the error message provided in the <c>resourceLocalized</c>.
        /// </para>
        /// <para>
        /// This method is internal and is used exclusively by the guard clauses.
        /// </para>
        /// </summary>
        /// <typeparam name="TParameter">The type of the parameter.</typeparam>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <remarks>
        /// If the <c>parameter</c> is <c>null</c>, the validation is ignored (i.e. does not throws an <c>TException</c>). This is useful for optional parameters whose default value is <c>null</c>.
        /// </remarks>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="predicate">The predicate to evaluate.</param>
        /// <param name="resourceLocalized">The resource localized message.</param>
        /// <param name="message">The optional error message that explains the reason for the exception. If this parameter is provided, it will override the error message described in the summary section.</param>
        /// <param name="parameterName">The name of the parameter with which <paramref name="parameter"/> corresponds.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentOutOfRangeException">.</exception>
        internal Guard Validate<TParameter, TException>(TParameter? parameter, Predicate<bool> predicate, string resourceLocalized, string message = "", string? parameterName = null)
            where TException : Exception
        {
            if (parameter is null)
                return this;

            Guard.Against.NullOrWhiteSpace(parameterName);

            if (predicate.Invoke(true))
                throw ExceptionFactory.NewException<TException>(resourceLocalized.OrFallback(message), parameterName)!;

            return this;
        }
    }
}
