using Krafted.DataAnnotations;
using Xunit;

namespace Krafted.UnitTest.Krafted.DataAnnotations
{
    [Trait(nameof(UnitTest), "Krafted.DataAnnotations")]
    public class EmailAddressRegexAttributeTest
    {
        [Theory]
        [InlineData("john@")]
        [InlineData("john@company")]
        [InlineData("@company.com")]
        [InlineData("john@.com")]
        [InlineData("john@company.")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsValid_InvalidEmail_False(string invalidEmail)
        {
            var model = new EmailModelDummy
            {
                MyProperty1 = invalidEmail,
                MyProperty2 = invalidEmail
            };

            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.False(isValid);
            Assert.Equal("Invalid e-mail address: MyProperty1.", validationResults[0].ErrorMessage);
            Assert.Equal("The e-mail should be valid.", validationResults[1].ErrorMessage);
        }

        [Fact]
        public void IsValid_ValidEmail_True()
        {
            var model = new EmailModelDummy
            {
                MyProperty1 = "john@company.com",
                MyProperty2 = "john@company.com"
            };

            var (isValid, validationResults) = ModelValidator.Validate(model);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
