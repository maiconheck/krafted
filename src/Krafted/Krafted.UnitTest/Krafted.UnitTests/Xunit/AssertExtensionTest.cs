using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.UnitTests.Xunit
{
    [Trait(nameof(UnitTest), "Krafted.UnitTests.Xunit")]
    public class AssertExtensionTest
    {
        [Fact]
        public void DoesNotThrows_TestCode_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                Guard.Against.Null(param);
            });
        }

        [Fact]
        public void ContainsNullGuardClause_ModelWithNullGuardClausesForAllParameters_Success()
        {
            string param1 = "My parameter 1";
            string param2 = "My parameter 2";
            string param3 = "My parameter 3";
            string param4 = "My parameter 4";
            string param5 = "My parameter 5";
            Assert.ContainsNullGuardClause<ModelWithNullGuardClausesForAllParameters>(param1, param2, param3, param4, param5);
        }

        [Fact]
        public void DoesNotContainNullGuardClause_ModelWithNullGuardClausesForSomeParameters_Fail()
        {
            string param1 = "My parameter 1";
            string param2 = "My parameter 2";
            string param3 = "My parameter 3";
            string param4 = "My parameter 4";
            string param5 = "My parameter 5";
            Assert.DoesNotContainNullGuardClause<ModelWithNullGuardClausesForSomeParameters>(param1, param2, param3, param4, param5);
        }

        [Fact]
        public void DoesNotContainNullGuardClause_ModelWithoutNullGuardClauses_Fail()
        {
            string param1 = "My parameter 1";
            string param2 = "My parameter 2";
            string param3 = "My parameter 3";
            string param4 = "My parameter 4";
            string param5 = "My parameter 5";
            Assert.DoesNotContainNullGuardClause<ModelWithoutNullGuardClauses>(param1, param2, param3, param4, param5);
        }
    }
}
