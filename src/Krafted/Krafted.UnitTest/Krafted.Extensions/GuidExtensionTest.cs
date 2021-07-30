using System;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
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

        [Fact]
        public void IsEmpty_NotEmptyGuid_False()
        {
            var notEmptyGuid = new Guid("5c246e85-c1af-4654-be86-81da9ab808bf");
            Assert.False(notEmptyGuid.IsEmpty());
        }
    }
}
