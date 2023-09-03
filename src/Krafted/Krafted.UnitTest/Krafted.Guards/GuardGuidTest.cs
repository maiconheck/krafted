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
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.Empty;
                Guard.Against.Empty(myGuid, nameof(myGuid));
            });
            Assert.Equal("Guid cannot be empty. (Parameter 'myGuid')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.Empty;
                Guard.Against.Empty(myGuid, nameof(myGuid), "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myGuid')", ex2.Message);
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
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.NewGuid();
                Guard.Against.NotEmpty(myGuid, nameof(myGuid));
            });
            Assert.Equal("Guid should be empty. (Parameter 'myGuid')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myGuid = Guid.NewGuid();
                Guard.Against.NotEmpty(myGuid, nameof(myGuid), "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myGuid')", ex2.Message);
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
