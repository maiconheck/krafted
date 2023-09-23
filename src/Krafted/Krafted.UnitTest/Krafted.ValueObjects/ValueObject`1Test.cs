using System.Globalization;
using Krafted.ValueObjects;
using Xunit;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class ValueObjectTTest
    {
        [Fact]
        public void Equals_EqualValueObjects_True()
        {
            Email? valueObjectA = new Email("contact@maiconheck.com");
            Email? valueObjectB = valueObjectA;
            Email valueObjectC = new Email("contact@maiconheck.com");

            Assert.True(valueObjectA.Equals(valueObjectA));

            Assert.True(valueObjectA.Equals(valueObjectB));
            Assert.True(valueObjectA == valueObjectB);
            Assert.False(valueObjectA != valueObjectB);

            Assert.True(valueObjectA.Equals(valueObjectC));
            Assert.True(valueObjectA == valueObjectC);
            Assert.False(valueObjectA != valueObjectC);

            valueObjectA = null;
            Assert.False(valueObjectA == valueObjectB);
            Assert.False(valueObjectB.Equals(valueObjectA));

            valueObjectA = null;
            valueObjectB = null;
            Assert.True(valueObjectA == valueObjectB);
        }

        [Fact]
        public void Equals_NotEqualValueObjects_False()
        {
            Email valueObjectA = new Email("foo@maiconheck.com");
            Email valueObjectB = new Email("bar@maiconheck.com");

            Assert.False(valueObjectA.Equals(valueObjectB));
            Assert.False(valueObjectA == valueObjectB);
            Assert.True(valueObjectA != valueObjectB);
        }

        [Fact]
        public void GetHashCode_Id_HashCode()
        {
            Email valueObjectA = new Email("foo@maiconheck.com");
            Email valueObjectB = new Email("bar@maiconheck.com");

            var hashCode1 = valueObjectA.GetHashCode();
            var hashCode2 = valueObjectB.GetHashCode();

            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void GetCopy_ValueObject_Copied()
        {
            Email valueObjectA = new Email("contact@maiconheck.com");
            Email valueObjectB = (Email)valueObjectA.GetCopy();

            Assert.True(valueObjectA.Equals(valueObjectB));
            Assert.True(valueObjectA == valueObjectB);
            Assert.False(valueObjectA != valueObjectB);

            Assert.Equal(valueObjectA.Value, valueObjectB.Value);
            Assert.Equal(valueObjectA.ToString(CultureInfo.InvariantCulture), valueObjectB.ToString(CultureInfo.InvariantCulture));
        }
    }
}
