using Xunit;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), nameof(DesignPatterns))]
    public class ValueObjectTest
    {
        [Fact]
        public void Equals_EqualValueObjects_True()
        {
            ValueObjectStub valueObjectA = new ValueObjectStub("Foo Street", "Foo City", "4567898");
            ValueObjectStub valueObjectB = valueObjectA;
            ValueObjectStub valueObjectC = new ValueObjectStub("Foo Street", "Foo City", "4567898");

            Assert.True(valueObjectA.Equals(valueObjectA));

            Assert.True(valueObjectA.Equals(valueObjectB));
            Assert.True(valueObjectA == valueObjectB);
            Assert.False(valueObjectA != valueObjectB);

            Assert.True(valueObjectA.Equals(valueObjectC));
            Assert.True(valueObjectA == valueObjectC);
            Assert.False(valueObjectA != valueObjectC);
        }

        [Fact]
        public void Equals_NotEqualValueObjects_False()
        {
            ValueObjectStub valueObjectA = new ValueObjectStub("Foo Street", "Foo City", "4567898");
            ValueObjectStub valueObjectB = new ValueObjectStub("Bar Street", "Foo City", "4567898");

            Assert.False(valueObjectA.Equals(valueObjectB));
            Assert.False(valueObjectA == valueObjectB);
            Assert.True(valueObjectA != valueObjectB);
        }

        [Fact]
        public void GetHashCode_Id_HashCode()
        {
            ValueObjectStub valueObjectA = new ValueObjectStub("Foo Street", "Foo City", "4567898");

            var hashCode1 = valueObjectA.GetHashCode();
            valueObjectA.SetStreet("Bar Street");
            var hashCode2 = valueObjectA.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void GetCopy_ValueObject_Copied()
        {
            ValueObjectStub valueObjectA = new ValueObjectStub("Foo Street", "Foo City", "4567898");
            ValueObjectStub valueObjectB = (ValueObjectStub)valueObjectA.GetCopy();

            Assert.True(valueObjectA.Equals(valueObjectB));
            Assert.True(valueObjectA == valueObjectB);
            Assert.False(valueObjectA != valueObjectB);

            Assert.Equal(valueObjectA.Street, valueObjectB.Street);
            Assert.Equal(valueObjectA.City, valueObjectB.City);
            Assert.Equal(valueObjectA.ZipCode, valueObjectB.ZipCode);
        }
    }
}
