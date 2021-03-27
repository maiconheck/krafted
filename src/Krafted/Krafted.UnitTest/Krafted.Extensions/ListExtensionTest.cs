using System.Collections.Generic;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
    public class ListExtensionTest
    {
        [Theory]
        [InlineData(2, 0, new int[] { 3, 1, 2 })]
        [InlineData(2, 1, new int[] { 1, 3, 2 })]
        [InlineData(0, 2, new int[] { 2, 3, 1 })]
        [InlineData(0, 1, new int[] { 2, 1, 3 })]
        [InlineData(1, 0, new int[] { 2, 1, 3 })]
        public void Move_NewOrder_Reordered(int oldIndex, int newIndex, int[] orderExpected)
        {
            // Arrange
            var source = new List<int> { 1, 2, 3 };

            // Act
            source.Move(oldIndex, newIndex);

            // Assert
            Assert.Equal(orderExpected[0], source[0]);
            Assert.Equal(orderExpected[1], source[1]);
            Assert.Equal(orderExpected[2], source[2]);
        }
    }
}
