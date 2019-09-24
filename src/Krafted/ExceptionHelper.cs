// A ExceptionHelper implementation.
//
// This class was inspired by and adapted from Giacomelli original implementation.
// Source: https://github.com/giacomelli/HelperSharp/blob/master/HelperSharp/ExceptionHelper.cs
// Retrieved in July 2019.

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Krafted
{
    /// <summary>
    /// Provides helper methods to handle exceptions.
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="param">The parameter to check if is null.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public static void ThrowIfNull<T>(this T param, string paramName)
            where T : class
        {
            if (param == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null.
        /// </summary>
        /// <param name="param">The parameter to check if is null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        public static void ThrowIfNull(Expression<Func<object>> param)
        {
            if (param == null)
                throw new ArgumentNullException(nameof(param));

            if (param.Compile().Invoke() == null)
            {
                var expressionBody = (MemberExpression)param.Body;
                var modelName = expressionBody.Member.Name;
                throw new ArgumentNullException(modelName);
            }
        }

        /// <summary>
        /// Throws an ArgumentNullException if any parameter is null.
        /// </summary>
        /// <param name="params">The parameters to check if any is null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="params"/> is <c>null</c>.</exception>
        public static void ThrowIfNull(params Expression<Func<object>>[] @params)
                => @params.ToList().ForEach(ThrowIfNull);

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null or an ArgumentException if is empty.
        /// </summary>
        /// <param name="param">The parameter to check if is null.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> is empty.</exception>
        public static void ThrowIfNullOrEmpty(this string param, string paramName)
        {
            param.ThrowIfNull(nameof(param));

            if (string.IsNullOrEmpty(param))
                throw new ArgumentException($"Argument {paramName} can't be empty.");
        }

        /// <summary>
        /// Throws an ArgumentNullException if the parameter is null or an ArgumentException if is empty,
        /// or consists only of white-space.
        /// </summary>
        /// <param name="param">The parameter to check if is null.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <exception cref="ArgumentNullException"><paramref name="param"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="param"/> is empty, or consists only of white-space.</exception>
        public static void ThrowIfNullOrWhiteSpace(this string param, string paramName)
        {
            param.ThrowIfNull(nameof(param));

            if (string.IsNullOrWhiteSpace(param))
                throw new ArgumentException($"Argument {paramName} can't be empty or white-space.");
        }
    }
}