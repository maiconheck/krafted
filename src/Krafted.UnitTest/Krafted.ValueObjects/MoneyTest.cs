using System;
using System.Globalization;
using Krafted.ValueObjects;
using Xunit;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait("Category", nameof(ValueObjects))]
    public class MoneyTest
    {
        [Theory]
        [InlineData(0, 0)]
        public void NewMoney_Empty_ShouldBeProperInstantiated(decimal expectedAmount, decimal expectedIntegralPart)
        {
            var money = new Money();
            Assert.Equal(expectedAmount, money.Amount);
            Assert.Equal(expectedIntegralPart, money.IntegralPart);
        }

        [Theory]
        [InlineData(10, 10, 10)]
        [InlineData(12.34, 12.34, 12)]
        [InlineData(0.34, 0.34, 0)]
        public void NewMoney_NotEmpty_ShouldBeProperInstantiated(decimal ammount, decimal expectedAmount, decimal expectedIntegralPart)
        {
            var money = new Money(ammount);
            Assert.Equal(expectedAmount, money.Amount);
            Assert.Equal(expectedIntegralPart, money.IntegralPart);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1)]
        public void Ammount_GreaterOrEqualThanZero_ShouldByValid(decimal ammount)
        {
            var money = new Money(ammount);
            Assert.True(money.Valid);
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(-1)]
        public void Ammount_LowerThanZero_ShouldByInvalid(decimal ammount)
        {
            var money = new Money(ammount);
            Assert.True(money.Invalid);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 15, 15)]
        [InlineData(10, 15, 25)]
        [InlineData(12.15, 0.15, 12.30)]
        [InlineData(12.99, 0.15, 13.14)]
        [InlineData(12.15, 1.15, 13.30)]
        public void Ammount_Incremented_ShouldBeIncremented(decimal ammount, decimal incremented, decimal expected)
        {
            var money = new Money(ammount);
            money += incremented;
            Assert.Equal(expected, money.Amount);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(15, 5, 10)]
        [InlineData(20, 15, 5)]
        [InlineData(20, 25, -5)]
        [InlineData(20.15, 25.10, -4.95)]
        [InlineData(12.15, 0.15, 12.00)]
        [InlineData(13.14, 0.15, 12.99)]
        [InlineData(12.15, 1.15, 11.00)]
        public void Ammount_Decremented_ShouldBeDecremented(decimal ammount, decimal decremented, decimal expected)
        {
            var money = new Money(ammount);
            money -= decremented;
            Assert.Equal(expected, money.Amount);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(-5)]
        public void Money_CastToDecimal_ShouldByCasted(decimal expected)
        {
            var actual = (decimal)new Money(expected);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(-5)]
        public void Decimal_CastToMoney_ShouldByCasted(decimal expected)
        {
            var actual = (Money)expected;
            Assert.Equal(expected, actual.Amount);
        }

        [Fact]
        public void Money_ToString_ShouldByCorrect()
        {
            if (CultureInfo.CurrentCulture.Name.Equals("pt-BR", StringComparison.Ordinal))
            {
                Assert.Equal("R$0,00", new Money(0M).ToString());
                Assert.Equal("R$0,99", new Money(0.99M).ToString());
                Assert.Equal("R$1,00", new Money(1M).ToString());
                Assert.Equal("R$12,34", new Money(12.34M).ToString());
            }
        }
    }
}
