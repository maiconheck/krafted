using System;
using Xunit;

namespace Krafted.Test.UnitTest.Xunit
{
    /// <summary>
    /// Provides assertion methods to xUnit <see cref="Assert"/>.
    /// </summary>
    public class AssertExtension : Assert
    {
        /// <summary>
        /// Verifies that no exception was thrown.
        /// </summary>
        /// <param name="testCode">The test code.</param>
        public static void DoesNotThrows(Action testCode)
        {
            var ex = Record.Exception(testCode);
            Null(ex);
        }
    }
}