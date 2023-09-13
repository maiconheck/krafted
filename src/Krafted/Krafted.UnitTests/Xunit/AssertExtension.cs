using System;
using System.Linq;
using System.Reflection;
using Krafted.Guards;
using Xunit;
using Xunit.Sdk;

namespace Krafted.UnitTests.Xunit
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

        /// <summary>
        /// Verifies that a type contains <c>Null Guard Clauses</c> for all parameters of it constructor.
        /// </summary>
        /// <typeparam name="T">The type of the object to be verified.</typeparam>
        /// <param name="parameters">An array of parameters that match in number, order, and type the parameters of the constructor.</param>
        public static void ContainsNullGuardClause<T>(params object?[] parameters) where T : class
        {
            Guard.Against.Null(parameters);
            Assert.True(AssertNullGuardClause<T>(parameters));
        }

        /// <summary>
        /// Verifies that a type does not contain <c>Null Guard Clauses</c> for any parameters of it constructor.
        /// </summary>
        /// <typeparam name="T">The type of the object to be verified.</typeparam>
        /// <param name="parameters">An array of parameters that match in number, order, and type the parameters of the constructor.</param>
        public static void DoesNotContainNullGuardClause<T>(params object?[] parameters) where T : class
        {
            Guard.Against.Null(parameters);
            Assert.False(AssertNullGuardClause<T>(parameters));
        }

        private static bool AssertNullGuardClause<TSut>(params object?[] parameters) where TSut : class
        {
            var type = typeof(TSut);

            if (!parameters.Any())
                throw new InvalidOperationException($"The constructor of the specified SUT '{type.Name}' does not contains any parameter.");

            // Try to create an instance of the SUT using null for each parameter, to ensure that each parameter has a 'Null Guard Clause'.
            for (int i = 0; i < parameters.Length; i++)
            {
                var localParams = GetOriginalParameters();
                localParams[i] = null!;

                try
                {
                    Assert.Throws<TargetInvocationException>(() => Activator.CreateInstance(type, localParams));
                }
                catch (XunitException)
                {
                    return false;
                }
            }

            return true;

            object[] GetOriginalParameters()
            {
                var originalParameters = new object[parameters.Length];
                parameters.CopyTo(originalParameters, 0);

                return originalParameters;
            }
        }
    }
}
