using System;
using Xunit;

namespace Krafted.UnitTest.Xunit
{
    /// <summary>
    /// Provides assertion methods to xUnit <see cref="Assert"/>.
    /// </summary>
    public class AssertExtension : Assert
    {
        /// <summary>
        /// Verifies that no exception was thrown.
        /// </summary>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        public static void DoesNotThrows(Action testCode)
        {
            var ex = Record.Exception(testCode);
            Null(ex);
        }

        /// <summary>
        /// Verifies that no exception was thrown.
        /// </summary>
        /// <param name="testCode">A delegate to the code to be tested.</param>
        public static void DoesNotThrows(Func<object> testCode)
        {
            var ex = Record.Exception(testCode);
            Null(ex);
        }
    }
}
