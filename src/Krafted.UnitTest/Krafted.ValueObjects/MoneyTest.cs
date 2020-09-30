using System;
using System.Globalization;
using Krafted.ValueObjects;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), nameof(ValueObjects))]
    public class MoneyTest
    {
        [Fact]
        public void NewMoney_Value_ProperInstantiated()
        {
            var money1 = new Money(0);
            Assert.Equal(0, money1.Value);
            Assert.Equal(0, money1.IntegralPart);

            var money2 = new Money(0m);
            Assert.Equal(0m, money2.Value);
            Assert.Equal(0m, money2.IntegralPart);

            var money3 = new Money(12.45m);
            Assert.Equal(12.45m, money3.Value);
            Assert.Equal(12m, money3.IntegralPart);

            var money4 = new Money(0.45m);
            Assert.Equal(0.45m, money4.Value);
            Assert.Equal(0m, money4.IntegralPart);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.01)]
        [InlineData(0.1)]
        [InlineData(1)]
        [InlineData(1.1)]
        [InlineData(1.5)]
        [InlineData(12.45)]
        [InlineData(2)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(1000000000)]
        [InlineData(9000000000)]
        public void NewMoney_ValueZeroOrGreater_DoesNotThrowsException(decimal value)
        {
            Assert.DoesNotThrows(() => new Money(value));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(-0.01)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(-12.45)]
        [InlineData(-1000)]
        [InlineData(-1000000000)]
        [InlineData(-9000000000)]
        public void NewMoney_LessThanZero_ThrowsException(decimal ammount)
        {
            Assert.Throws<ArgumentException>(() => new Money(ammount));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 15, 15)]
        [InlineData(10, 15, 25)]
        [InlineData(12.15, 0.15, 12.30)]
        [InlineData(12.99, 0.15, 13.14)]
        [InlineData(12.15, 1.15, 13.30)]
        public void Money_Incremented_ShouldBeIncremented(decimal value, decimal increment, decimal expected)
        {
            var money = new Money(value);
            money += increment;
            Assert.Equal(expected, money.Value);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(15, 5, 10)]
        [InlineData(20, 15, 5)]
        [InlineData(25, 20, 5)]
        [InlineData(25.10, 20.15, 4.95)]
        [InlineData(12.15, 0.15, 12.00)]
        [InlineData(13.14, 0.15, 12.99)]
        [InlineData(12.15, 1.15, 11.00)]
        public void Money_Decremented_ShouldBeDecremented(decimal value, decimal decrement, decimal expected)
        {
            var money = new Money(value);
            money -= decrement;
            Assert.Equal(expected, money.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(9000000000)]
        public void Money_CastToDecimal_ShouldBeCasted(decimal expected)
        {
            var actual = (decimal)new Money(expected);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(9000000000)]
        public void Decimal_CastToMoney_ShouldByCasted(decimal expected)
        {
            var actual = (Money)expected;
            Assert.Equal(expected, actual.Value);
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
