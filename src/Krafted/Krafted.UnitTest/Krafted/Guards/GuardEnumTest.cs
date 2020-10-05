using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    public enum OrderStatus
    {
        InProgress = 1,
        Ordered = 2,
        Paid = 3
    }

    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class GuardEnumTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void GuardAgainstNotExists_NotExists_ThrowsException(int value)
        {
            var ex = Assert.Throws<ArgumentException>(() => Guard.Against.NotExists<OrderStatus>(value));
            Assert.Equal($"{value} not exists in the OrderStatus.", ex.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuardAgainstNotExists_Exists_DoesNotThrows(int value)
        {
            Assert.DoesNotThrows(() => Guard.Against.NotExists<OrderStatus>(value));
        }
    }
}
