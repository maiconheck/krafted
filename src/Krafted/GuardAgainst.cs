// A Guard Clauses implementation.
//
// This class was inspired by and adapted from Giacomelli original implementation.
// Source: https://github.com/giacomelli/HelperSharp/blob/master/HelperSharp/ExceptionHelper.cs
// Retrieved in July 2019.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Krafted
{
    /// <summary>
    /// Provides guard clauses to validate method arguments, in order to enforce defensive programming practice.
    /// <a href="https://en.wikipedia.org/wiki/Defensive_programming">See more</a>
    /// </summary>
    public static class GuardAgainst
    {
        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="param">The parameter to check.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public static void Null<T>(T param, string paramName)
            where T : class
        {
            if (param is null)
                throw new ArgumentNullException(paramName, Texts.ParameterCannotBeNull);
        }

        /// <summary>
        /// Throws an ArgumentNullException if any of the parameters are null.
        /// </summary>
        /// <param name="params">The parameters to check.</param>
        /// <exception cref="ArgumentNullException"><paramref name="params"/> is <c>null</c>.</exception>
        public static void AnyNull(params Expression<Func<object>>[] @params)
        {
            if (@params == null)
                throw new ArgumentNullException(nameof(@params), Texts.ParameterCannotBeNull);

            foreach (var param in @params)
            {
                if (param is null)
                    throw new ArgumentNullException(nameof(param), Texts.ParameterCannotBeNull);

                var value = param.Compile().Invoke();
                if (value is null)
                {
                    var memberName = ((MemberExpression)param.Body).Member.Name;
                    throw new ArgumentNullException(memberName, Texts.ParameterCannotBeNull);
                }
            }
        }

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null or an empty string.
        /// </summary>
        /// <param name="param">The parameter to check.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public static void NullOrEmpty(string param, string paramName)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentNullException(paramName, Texts.ParameterCannotBeNullOrEmpty);
        }

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null or an empty collection.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="param">The parameter to check.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public static void NullOrEmpty<T>(IEnumerable<T> param, string paramName)
        {
            if (param is null || !param.Any())
                throw new ArgumentNullException(paramName, Texts.ParameterCannotBeNullOrEmpty);
        }

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null, an empty string or consists only of white-space.
        /// </summary>
        /// <param name="param">The parameter to check.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> is empty, or consists only of white-space.</exception>
        public static void NullOrWhiteSpace(string param, string paramName)
        {
            if (string.IsNullOrWhiteSpace(param))
                throw new ArgumentNullException(paramName, Texts.ParameterCannotBeNullEmptyOrWhiteSpace);
        }
    }
}
