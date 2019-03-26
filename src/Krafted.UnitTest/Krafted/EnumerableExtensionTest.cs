using System.Collections.Generic;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class EnumerableExtensionTest
    {
        [Fact]
        public void ContainsAll_Itens_True()
        {
            var source = new int[] { 1, 2, 3 };
            var values = new int[] { 1, 2, 3 };
            Assert.True(source.ContainsAll(values));

            source = new int[] { 1, 2, 3 };
            values = new int[] { 1, 2 };
            Assert.True(source.ContainsAll(values));
        }

        [Fact]
        public void ContainsAll_Itens_False()
        {
            var source = new int[] { 1, 2, 3 };
            var values = new int[] { 1, 2, 3, 4 };
            Assert.False(source.ContainsAll(values));

            source = new int[] { 1, 2, 3 };
            values = new int[] { 4 };
            Assert.False(source.ContainsAll(values));
        }
    }
}
