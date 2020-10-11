using System;
using Krafted.ValueObjects;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), nameof(ValueObjects))]
    public class EmailTest
    {
        [Fact]
        public void NewEmail_Value_ProperInstantiated()
        {
            var email1 = new Email("contact@maiconheck.com");
            Assert.Equal("contact@maiconheck.com", email1.Value);
            Assert.Equal("contact@maiconheck.com", email1.ToString());

            var email2 = (Email)"contact@maiconheck.com";
            Assert.Equal("contact@maiconheck.com", email2.Value);
            Assert.Equal("contact@maiconheck.com", email2.ToString());

            var email3 = Email.NewEmail("contact@maiconheck.com");
            Assert.Equal("contact@maiconheck.com", email3.Value);
            Assert.Equal("contact@maiconheck.com", email3.ToString());
        }

        [Theory]
        [InlineData("contact@maiconheck.")]
        [InlineData("contact@maiconheck")]
        [InlineData("contact@")]
        [InlineData("contact@.com")]
        [InlineData("@maiconheck.com")]
        public void NewEmail_InvalidEmail_ThrowsException(string invalidEmail)
        {
            var ex = Assert.Throws<FormatException>(() => new Email(invalidEmail));
            Assert.Equal($"Invalid e-mail address: {invalidEmail}.", ex.Message);
        }

        [Fact]
        public void NewEmail_ValidEmail_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() => new Email("contact@maiconheck.com"));
        }
    }
}
