using System;

namespace Krafted.Guards
{
    /// <summary>
    /// Provides a factory method to create a new instance of <c>TException</c>.
    /// </summary>
    internal static class ExceptionFactory
    {
        /// <summary>
        /// Creates a new exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="parameterName">The name of the parameter that caused the current exception.</param>
        /// <returns>A new instance of TException.</returns>
        internal static TException? NewException<TException>(string message, string parameterName)
            where TException : Exception
        {
            var exceptionType = typeof(TException);

            if (exceptionType == typeof(ArgumentException))
                return Activator.CreateInstance(typeof(TException), message!, parameterName!) as TException;
            else if (exceptionType == typeof(ArgumentOutOfRangeException))
                return Activator.CreateInstance(typeof(TException), parameterName!, message!) as TException;
            else
                return Activator.CreateInstance(typeof(TException), message!) as TException;
        }
    }
}
