using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Test.UnitTests
{
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
