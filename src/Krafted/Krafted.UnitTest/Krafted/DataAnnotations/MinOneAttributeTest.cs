using Krafted.DataAnnotations;
using Xunit;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class MinOneAttributeTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1111111111111111111L, -111111111111111.11)]
        [InlineData(-2, -2222222222222222222L, -222222222222222.22)]
        [InlineData(-100, -999999999999999999L, -99999999999999.99)]
        public void IsValid_ZeroAndNegativeInt_False(int negativeInt, long negativeLong, decimal negativeDecimal)
        {
            var modelInt = new MinOneIntModelDummy
            {
                MyProperty1 = negativeInt,
                MyProperty2 = negativeInt
            };

            var modelLong = new MinOneLongModelDummy
            {
                MyProperty1 = negativeLong,
                MyProperty2 = negativeLong
            };

            var modelDecimal = new MinOneDecimalModelDummy
            {
                MyProperty1 = negativeDecimal,
                MyProperty2 = negativeDecimal
            };

            AssertLocal(modelInt);
            AssertLocal(modelLong);
            AssertLocal(modelDecimal);

            void AssertLocal(object model)
            {
                var (isValid, validationResults) = ModelValidator.Validate(model);

                Assert.False(isValid);
                Assert.Equal("The MyProperty1 must be at least one.", validationResults[0].ErrorMessage);
                Assert.Equal("The number should be positive.", validationResults[1].ErrorMessage);
            }
        }

        [Theory]
        [InlineData(1, 1111111111111111111L, 111111111111111.11)]
        [InlineData(2, 2222222222222222222L, 222222222222222.22)]
        [InlineData(100, 999999999999999999L, 99999999999999.99)]
        public void IsValid_PositiveInt_True(int positiveInt, long positiveLong, decimal positiveDecimal)
        {
            var modelInt = new MinOneIntModelDummy
            {
                MyProperty1 = positiveInt,
                MyProperty2 = positiveInt
            };

            var modelLong = new MinOneLongModelDummy
            {
                MyProperty1 = positiveLong,
                MyProperty2 = positiveLong
            };

            var modelDecimal = new MinOneDecimalModelDummy
            {
                MyProperty1 = positiveDecimal,
                MyProperty2 = positiveDecimal
            };

            AssertLocal(modelInt);
            AssertLocal(modelLong);
            AssertLocal(modelDecimal);

            void AssertLocal(object model)
            {
                var (isValid, validationResults) = ModelValidator.Validate(model);

                Assert.True(isValid);
                Assert.Empty(validationResults);
            }
        }
    }
}
