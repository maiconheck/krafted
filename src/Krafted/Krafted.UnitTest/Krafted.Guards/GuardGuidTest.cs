using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardGuidTest
    {
        [Fact]
        public void GuardAgainstEmpty_Empty_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.Empty;
                Guard.Against.Empty(myGuid, nameof(myGuid));
            });
            Assert.Equal("Guid cannot be empty. (Parameter 'myGuid')", ex.Message);
        }

        [Fact]
        public void GuardAgainstEmpty_NotEmpty_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myGuid = Guid.NewGuid();
                Guard.Against.Empty(myGuid, nameof(myGuid));
            });
        }

        [Fact]
        public void GuardAgainstNotEmpty_NotEmpty_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.NewGuid();
                Guard.Against.NotEmpty(myGuid, nameof(myGuid));
            });
            Assert.Equal("Guid should be empty. (Parameter 'myGuid')", ex.Message);
        }

        [Fact]
        public void GuardAgainstNotEmpty_Empty_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myGuid = Guid.Empty;
                Guard.Against.NotEmpty(myGuid, nameof(myGuid));
            });
        }
    }
}
