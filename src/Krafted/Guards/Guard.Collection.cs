using System;
using System.Collections;

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
        /// Throws an <see cref="ArgumentException"/> if the <c>collection</c> is empty,
        /// with this error message: Collection cannot be empty.
        /// </summary>
        /// <param name="collection">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard Empty(ICollection collection, string parameterName)
        {
            Guard.Against.
                Null(collection, nameof(collection)).
                NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (collection.Count == 0)
                throw new ArgumentException(Texts.CollectionCannotBeEmpty, parameterName);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the <c>collection</c> is not empty,
        /// with this error message: Collection should be empty.
        /// </summary>
        /// <param name="collection">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentException">.</exception>
        public Guard NotEmpty(ICollection collection, string parameterName)
        {
            Guard.Against.
                Null(collection, nameof(collection)).
                NullOrWhiteSpace(parameterName, nameof(parameterName));

            if (collection.Count > 0)
                throw new ArgumentException(Texts.CollectionShouldBeEmpty, parameterName);

            return this;
        }
    }
}
