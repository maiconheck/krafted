using Krafted.Test.Result;
using Xunit;

namespace Krafted.UnitTest.Krafted.Test.Result
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class NotificationTest
    {
        [Fact]
        public void NewNotification_NotificationCreated()
        {
            var notification = new Notification
            {
                Property = "The property",
                Message = "The message"
            };

            Assert.Equal("The property", notification.Property);
            Assert.Equal("The message", notification.Message);
        }
    }
}