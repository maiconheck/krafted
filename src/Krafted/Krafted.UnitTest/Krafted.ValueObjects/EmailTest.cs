using System;
using Krafted.ValueObjects;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class EmailTest
    {
        [Theory]
        [InlineData("email@example.com")]
        [InlineData("firstname.lastname@example.com")]
        [InlineData("firstname+lastname@example.com")]
        [InlineData("firstname-lastname@example.com")]
        [InlineData("firstname_lastname@domain.com")]
        [InlineData("email@subdomain.example.com")]
        [InlineData("email@example-one.com")]
        [InlineData("1234567890@example.com")]
        [InlineData("customer/department=shipping@example.com")]
        [InlineData("$A12345@example.com")]
        [InlineData("__somename@example.com")]
        public void NewEmail_ValidEmail_DoesNotThrowsException(string validEmail)
        {
            Assert.DoesNotThrows(() => new Email(validEmail));
            Assert.DoesNotThrows(() => (Email)validEmail);
            Assert.DoesNotThrows(() => Email.NewEmail(validEmail));
        }

        [Theory]
        [InlineData("email@example.")]
        [InlineData("example@example")]
        [InlineData("customer@")]
        [InlineData("customer@.com")]
        [InlineData("@domain.com")]
        [InlineData("email.example.com")]
        [InlineData("email@example@example.com")]
        [InlineData(".email@example.com")]
        [InlineData("email.@example.com")]
        [InlineData("email..email@example.com")]
        [InlineData("email@example.com (Joe Smith)")]
        [InlineData("email@example")]
        [InlineData("email@-example.com")]
        [InlineData("email@example..com")]
        [InlineData("email@example..co.uk")]
        public void NewEmail_InvalidEmail_ThrowsException(string invalidEmail)
        {
            var ex1 = Assert.Throws<FormatException>(() => new Email(invalidEmail));
            Assert.Equal($"Invalid e-mail address: {invalidEmail}.", ex1.Message);

            var ex2 = Assert.Throws<FormatException>(() => (Email)invalidEmail);
            Assert.Equal($"Invalid e-mail address: {invalidEmail}.", ex2.Message);

            var ex3 = Assert.Throws<FormatException>(() => Email.NewEmail(invalidEmail));
            Assert.Equal($"Invalid e-mail address: {invalidEmail}.", ex3.Message);
        }

        [Fact]
        public void NewEmail_ToString_StringEmail()
        {
            const string expected = "contact@domain.com";

            Assert.Equal(expected, new Email(expected).ToString());
            Assert.Equal(expected, ((Email)expected).ToString());
            Assert.Equal(expected, Email.NewEmail(expected).ToString());
        }
    }
}
