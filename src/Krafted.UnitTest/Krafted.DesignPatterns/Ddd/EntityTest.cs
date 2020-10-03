using Xunit;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class EntityTest
    {
        [Fact]
        public void Equals_EqualEntities_True()
        {
            EntityStub entityA = new EntityStub(20, "John");
            EntityStub entityB = entityA;
            EntityStub entityC = new EntityStub(20, "John");

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
            EntityStub entityA = new EntityStub(20, "John");
            EntityStub entityB = new EntityStub(20, "John");

            Assert.False(entityA.Equals(entityB));
            Assert.False(entityA == entityB);
            Assert.True(entityA != entityB);
        }

        [Fact]
        public void GetHashCode_Id_HashCode()
        {
            EntityStub entityA = new EntityStub(20, "John");

            var hashCode1 = entityA.GetHashCode();
            entityA.SetId(1);
            var hashCode2 = entityA.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }
    }
}
