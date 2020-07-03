using System.Linq;
using Krafted.ValueObjects;
using Xunit;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait("Category", nameof(ValueObjects))]
    public class EmailTest
    {
        [Fact]
        public void Email_InvalidAddress_Invalid()
        {
            var email = new Email("InvalidEmail");

            Assert.True(email.Invalid);
            Assert.Single(email.Notifications);
            Assert.Equal("E-mail inválido.", email.Notifications.First().Message);
        }

        [Fact]
        public void Email_ValidAddress_Valid()
        {
            const string validAddress = "contact@maiconheck.com.br";
            var email = new Email(validAddress);

            Assert.True(email.Valid);
            Assert.Empty(email.Notifications);
            Assert.Equal(validAddress, email.Address);
            Assert.Equal(validAddress, email.ToString());

            var emailConverted = (Email)validAddress;
            Assert.Equal(validAddress, emailConverted.Address);
        }
    }
}
