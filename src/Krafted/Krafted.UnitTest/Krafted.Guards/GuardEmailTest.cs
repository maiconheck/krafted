using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardEmailTest
    {
        [Theory]
        [InlineData("john@")]
        [InlineData("john@company")]
        [InlineData("@company.com")]
        [InlineData("john@.com")]
        [InlineData("john@company.")]
        public void GuardAgainstInvalidEmail_InvalidEmail_ThrowsException(string invalidEmail)
        {
            var ex = Assert.Throws<FormatException>(() => Guard.Against.InvalidEmail(invalidEmail));
            Assert.Equal("Invalid e-mail address: {0}.".Format(invalidEmail), ex.Message);
        }

        [Fact]
        public void GuardAgainstInvalidEmail_ValidEmail_DoesNotThrowsException()
        {
            const string validEmail = "john@company.com";
            Assert.DoesNotThrows(() => Guard.Against.InvalidEmail(validEmail));
        }
    }
}
