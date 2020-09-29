using Krafted.DataAnnotations;
using Xunit;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    public class MinOneAttributeTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void IsValid_ZeroAndNegative_False(int negative)
        {
            var model = new MinOneModelDummy
            {
                MyProperty1 = negative,
                MyProperty2 = negative
            };

            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.False(isValid);
            Assert.Equal("The MyProperty1 must be at least one.", validationResults[0].ErrorMessage);
            Assert.Equal("The number should be positive.", validationResults[1].ErrorMessage);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void IsValid_Positive_True(int positive)
        {
            var model = new MinOneModelDummy
            {
                MyProperty1 = positive,
                MyProperty2 = positive
            };

            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
