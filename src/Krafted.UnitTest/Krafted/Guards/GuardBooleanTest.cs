using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class GuardBooleanTest
    {
        [Fact]
        public void GuardAgainstTrue_True_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                bool myParam = true;
                Guard.Against.True(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be true. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void GuardAgainstTrue_False_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                bool myParam = false;
                Guard.Against.True(myParam, nameof(myParam));
            });
        }

        [Fact]
        public void GuardAgainstFalse_False_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                bool myParam = false;
                Guard.Against.False(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be false. (Parameter 'myParam')", ex.Message);
        }

        [Fact]
        public void GuardAgainstFalse_True_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                bool myParam = true;
                Guard.Against.False(myParam, nameof(myParam));
            });
        }
    }
}
