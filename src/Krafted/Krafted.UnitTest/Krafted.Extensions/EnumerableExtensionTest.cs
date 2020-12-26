using System.Collections.Generic;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
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

        [Fact]
        public void Ordinal_Itens_Ok()
        {
            var itens1 = new int[] { 1, 2, 3, 4, 5 };
            Assert.Equal(2, itens1.Second());
            Assert.Equal(3, itens1.Third());
            Assert.Equal(4, itens1.Fourth());
            Assert.Equal(5, itens1.Fifth());

            var itens2 = new string[] { "A", "B", "C", "D", "E" };
            Assert.Equal("B", itens2.Second());
            Assert.Equal("C", itens2.Third());
            Assert.Equal("D", itens2.Fourth());
            Assert.Equal("E", itens2.Fifth());
        }

        [Fact]
        public void Empty_SourceContainsElements_False()
        {
            var source = new int[] { 1, 2, 3, 4, 5 };
            Assert.False(source.Empty());
        }

        [Fact]
        public void Empty_SourceNotContainsElements_True()
        {
            var source = new int[] { };
            Assert.True(source.Empty());
        }
    }
}
