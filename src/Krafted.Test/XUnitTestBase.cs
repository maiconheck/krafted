using System;
using Xunit;

namespace Krafted.Test
{
    /// <summary>
    /// Provides some assertion methods to Unit Test classes.
    /// </summary>
    /// <seealso cref="ITest" />
    public abstract class XUnitTestBase : ITest
    {
        /// <summary>
        /// Verifies that an exception is thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        public static void Throws(in Action testCode) => Record.Exception(testCode);

        /// <summary>
        /// Verifies that the exact exception is thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        /// <typeparam name="T">The exception type.</typeparam>
        public void Throws<T>(in Action testCode)
            where T : Exception
        {
            var ex = Record.Exception(testCode);
            Assert.IsType<T>(ex);
        }

        /// <summary>
        /// Verifies that no exception was thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        public void DoesNotThrows(Action testCode)
        {
            var ex = Record.Exception(testCode);
            Assert.Null(ex);
        }
    }
}