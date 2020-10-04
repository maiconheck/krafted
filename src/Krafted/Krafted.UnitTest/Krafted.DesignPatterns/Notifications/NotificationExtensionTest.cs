using System.Collections.Generic;
using System.Linq;
using Krafted.DesignPatterns.Notifications;
using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class NotificationExtensionTest
    {
        [Fact]
        public void NewModel_ValidatorRulesSatisfied_Valid()
        {
            var model = new ModelStub(19, "John");
            Assert.True(model.Valid());
            Assert.False(model.Invalid());
            Assert.Equal(0, model.Notifications.Count);
        }

        [Fact]
        public void NewModel_ValidatorRulesUnsatisfied_Valid()
        {
            var model = new ModelStub(18, string.Empty);
            Assert.False(model.Valid());
            Assert.True(model.Invalid());
            Assert.Equal(3, model.Notifications.Count);
        }

        [Fact]
        public void AddNotification_LocalizedMessage_NotificationAdded()
        {
            var model = new ModelStub(19, "John");
            model.AddNotification("localized_resource");
            var notification = model.Notifications.First();

            Assert.Equal("localized_resource", notification.Key);
            Assert.Equal("localized_resource", notification.Message);
            Assert.True(notification.Localized);
        }

        [Fact]
        public void AllModelsValid_AllValid_True()
        {
            var models = new List<ModelStub>
            {
                new ModelStub(19, "John"),
                new ModelStub(20, "John 2"),
                new ModelStub(21, "John 3")
            };

            Assert.True(models.AllValid());
        }

        [Fact]
        public void OneModelInvalid_AnyInvalid_True()
        {
            var models = new List<ModelStub>
            {
                new ModelStub(18, "John"),
                new ModelStub(20, "John 2"),
                new ModelStub(21, "John 3")
            };

            Assert.True(models.AnyInvalid());
        }
    }
}
