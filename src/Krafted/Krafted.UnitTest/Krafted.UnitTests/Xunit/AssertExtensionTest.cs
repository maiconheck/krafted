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
                Guard.Against.Null(param, nameof(param));
            });
        }
    }
}
