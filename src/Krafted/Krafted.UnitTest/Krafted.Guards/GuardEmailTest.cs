using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

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
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.InvalidEmail(invalidEmail));
            Assert.Equal("Invalid e-mail address: {0}. (Parameter 'invalidEmail')".Format(invalidEmail), ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.InvalidEmail(invalidEmail, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'invalidEmail')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstInvalidEmail_ValidEmail_DoesNotThrowsException()
        {
            const string validEmail = "john@company.com";
            Assert.DoesNotThrows(() => Guard.Against.InvalidEmail(validEmail));
        }

        [Fact]
        public void GuardAgainstInvalidEmail_Null_DoesNotThrowsException()
        {
            const string? email = null;
            Assert.DoesNotThrows(() => Guard.Against.InvalidEmail(email));
        }
    }
}
