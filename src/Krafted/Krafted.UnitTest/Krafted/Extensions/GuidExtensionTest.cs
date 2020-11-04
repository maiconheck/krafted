using System;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class GuidExtensionTest
    {
        [Fact]
        public void IsEmpty_EmptyGuid_True()
        {
            var emptyGuid1 = Guid.Empty;
            Assert.True(emptyGuid1.IsEmpty());

            var emptyGuid2 = new Guid("00000000-0000-0000-0000-000000000000");
            Assert.True(emptyGuid2.IsEmpty());
        }
    }
}
