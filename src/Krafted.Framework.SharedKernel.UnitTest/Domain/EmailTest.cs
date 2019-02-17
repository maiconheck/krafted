using Xunit;
using Krafted.Framework.SharedKernel.Domain;

namespace Krafted.Framework.SharedKernel.UnitTest.Domain
{
    [Trait("Category", nameof(Domain))]
    public class EmailTest
    {
        [Fact]
        public void Email_InvalidValue_Invalid()
        {
            var email = new Email("InvalidEmail");

            Assert.False(email.Valid);
            Assert.True(email.Notifications.Count == 1);
        }

        [Fact]
        public void Email_ValidValue_Valid()
        {
            var email = new Email("contact@maiconheck.com.br");

            Assert.True(email.Valid);
            Assert.True(email.Notifications.Count == 0);
        }
    }
}