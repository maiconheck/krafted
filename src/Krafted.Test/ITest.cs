using System;

namespace Krafted.Test
{
    /// <summary>
    /// Provides an interface to base unit test classes in order to abstract
    /// the different implementations between xUnit and NUnit and so on.
    /// </summary>
    public interface ITest
    {
        /// <summary>
        /// Verifies that the exact exception is thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        /// <typeparam name="T">The exception type.</typeparam>
        void Throws<T>(in Action testCode)
            where T : Exception;

        /// <summary>
        /// Verifies that no exception was thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        void DoesNotThrows(Action testCode);
    }
}