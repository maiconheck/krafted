using Xunit;
using Krafted.Framework.SharedKernel.Domain;

namespace Krafted.Framework.SharedKernel.UnitTest.Domain
{
    [Trait("Category", nameof(Domain))]
    public class MoneyTest
    {
        [Fact]
        public void NewMoney_NotEmpty_Valid()
        {
            var money = new Money(10M);

            Assert.True(money.Valid);
        }

        [Fact]
        public void IntegralPart_20And30_ShouldBe20()
        {
            var money = new Money(20.30M);

            decimal expected = 20M;
            decimal actual = money.IntegralPart;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Increase10_By15_ShouldBe25()
        {
            var money = new Money(10M);
            money += 15M;

            decimal expected = 25M;
            decimal actual = money.Amount;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Decrease30And15_By20And10_ShouldBe10And5()
        {
            var money = new Money(30M);
            money -= 20M;

            decimal expected = 10M;
            decimal actual = money.Amount;

            Assert.Equal(expected, actual);
        }
    }
}