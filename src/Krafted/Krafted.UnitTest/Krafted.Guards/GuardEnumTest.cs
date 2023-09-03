using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    public enum OrderStatus
    {
        InProgress = 1,
        Ordered = 2,
        Paid = 3
    }

    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardEnumTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public void GuardAgainstNotExists_NotExists_ThrowsException(int value)
        {
            var orderStatus = (OrderStatus)value;

            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.NotExists(orderStatus));
            Assert.Equal($"{value} not exists in the OrderStatus.", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.NotExists(orderStatus, "My custom error message."));
            Assert.Equal("My custom error message.", ex2.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuardAgainstNotExists_Exists_DoesNotThrows(int value)
        {
            var orderStatus = (OrderStatus)value;
            Assert.DoesNotThrows(() => Guard.Against.NotExists(orderStatus));
        }
    }
}
