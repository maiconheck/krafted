using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class EntityTest
    {
        [Fact]
        public void Equals_EqualEntities_True()
        {
            EntityStub entityA = new EntityStub(20, "John", "john@company.com");
            EntityStub entityB = entityA;
            EntityStub entityC = new EntityStub(20, "John", "john@company.com");

            Assert.True(entityA.Equals(entityA));
            Assert.True(entityA.Equals(entityB));
            Assert.True(entityA == entityB);
            Assert.False(entityA != entityB);

            entityA.SetId(1);
            entityC.SetId(1);
            Assert.True(entityA.Equals(entityC));
        }

        [Fact]
        public void Equals_NotEqualEntities_False()
        {
            EntityStub entityA = new EntityStub(20, "John", "john@company.com");
            EntityStub entityB = new EntityStub(20, "John", "john@company.com");

            Assert.False(entityA.Equals(entityB));
            Assert.False(entityA == entityB);
            Assert.True(entityA != entityB);
        }

        [Fact]
        public void GetHashCode_Id_HashCode()
        {
            EntityStub entityA = new EntityStub(20, "John", "john@company.com");

            var hashCode1 = entityA.GetHashCode();
            entityA.SetId(1);
            var hashCode2 = entityA.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void PublishEvent_Event_EventPublished()
        {
            var entity = new EntityStub(20, "John", "john@company.com");
            Assert.Equal(1, entity.DomainEvents.Count);

            entity.Lock();
            Assert.Equal(2, entity.DomainEvents.Count);
        }

        [Fact]
        public void NewEntity_Valid_True()
        {
            var entity = new EntityStub(20, "John", "john@company.com");
            Assert.True(entity.Valid);
            Assert.False(entity.Invalid);
            Assert.Empty(entity.Notifications);
        }

        [Fact]
        public void LockUser_UserAlreadyLocked_NotificationAdded()
        {
            var user = new EntityStub(20, "John", "john@company.com");
            Assert.Empty(user.Notifications);

            user.Lock();
            Assert.Empty(user.Notifications);

            user.Lock();
            Assert.NotEmpty(user.Notifications);
            Assert.Equal(1, user.Notifications.Count);
        }

        [Fact]
        public void EditUser_InvalidData_NotificationsAdded()
        {
            var user = new EntityStub(20, "John", "john@company.com");
            Assert.Empty(user.Notifications);

            user.Edit(0, string.Empty);
            Assert.NotEmpty(user.Notifications);
            Assert.Equal(2, user.Notifications.Count);
        }
    }
}
