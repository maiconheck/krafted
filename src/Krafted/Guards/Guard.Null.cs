using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null,
        /// with this error message: Parameter cannot be null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        /// <returns>The guard.</returns>
        public Guard Null<T>(T parameter, string parameterName)
        {
            if (parameter is null)
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNull);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null or an empty string,
        /// with this error message: Parameter cannot be null or empty.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        public Guard NullOrEmpty(string parameter, string parameterName)
        {
            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNullOrEmpty);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null or an empty collection,
        /// with this error message: Parameter cannot be null or empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        public Guard NullOrEmpty<T>(IEnumerable<T> parameter, string parameterName)
        {
            if (parameter is null || !parameter.Any())
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNullOrEmpty);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null, an empty string or consists only of white-space,
        /// with this error message: Parameter cannot be null, empty or consists exclusively of white-space characters.
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameter"/> is empty, or consists only of white-space.</exception>
        public Guard NullOrWhiteSpace(string parameter, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(parameterName, Texts.ParameterCannotBeNullEmptyOrWhiteSpace);

            return this;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <c>parameter</c> is null, an empty string or consists only of white-space,
        /// with an custom error message plus "(Parameter 'myParamName')".
        /// e.g. My custom error message (Parameter 'myParamName').
        /// </summary>
        /// <param name="parameter">The parameter to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="customErrorMessage">
        /// A custom error message that describes the error (e.g. Could not find a connection string named 'MyConnection'.).
        /// </param>
        /// <returns>The guard.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameter"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="parameter"/> is empty, or consists only of white-space.</exception>
        public Guard NullOrWhiteSpace(string parameter, string parameterName, string customErrorMessage)
        {
            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentNullException(parameterName, customErrorMessage);

            return this;
        }
    }
}
