using System.Collections.Generic;
using Xunit;

namespace Krafted.UnitTest
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class EnumerableExtensionTest
    {
        [Fact]
        public void ContainsAll_Itens_True()
        {
            var values = new int[] { 1, 2, 3 };
            var source = new int[] { 1, 2, 3 };
            Assert.True(source.ContainsAll(values));

            values = new int[] { 1, 2 };
            source = new int[] { 1, 2, 3 };
            Assert.True(source.ContainsAll(values));
        }

        [Fact]
        public void ContainsAll_Itens_False()
        {
            var values = new int[] { 1, 2, 3, 4 };
            var source = new int[] { 1, 2, 3 };
            Assert.False(source.ContainsAll(values));
        }
    }
}
