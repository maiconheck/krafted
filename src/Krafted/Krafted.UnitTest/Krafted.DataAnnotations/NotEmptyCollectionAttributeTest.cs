using Krafted.DataAnnotations;
using Xunit;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    [Trait(nameof(UnitTest), "Krafted.DataAnnotations")]
    public class NotEmptyCollectionAttributeTest
    {
        [Fact]
        public void IsValid_Empty_False()
        {
            var model = new NotEmptyCollectionModelDummy();
            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.False(isValid);
            Assert.Equal("At least one item is required.", validationResults[0].ErrorMessage);
            Assert.Equal("Provide at least one item.", validationResults[1].ErrorMessage);
        }

        [Theory]
        [InlineData(new int[] { 1 })]
        [InlineData(new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3 })]
        public void IsValid_NotEmpty_True(int[] items)
        {
            var model = new NotEmptyCollectionModelDummy
            {
                MyProperty1 = items,
                MyProperty2 = items
            };

            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
