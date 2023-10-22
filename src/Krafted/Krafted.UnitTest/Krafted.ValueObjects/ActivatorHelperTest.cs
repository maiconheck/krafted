using System;
using Krafted.ValueObjects;
using Krafted.ValueObjects.Pt;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class ActivatorHelperTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateInstance_NullOrEmptyNif_InstanceCreated(string nullOrEmptyNif)
        {
            Assert.DoesNotThrows(() =>
            {
                var nif = ActivatorHelper.CreateInstance<Nif>(nullOrEmptyNif);
                Assert.NotNull(nif);
            });
        }

        [Theory]
        [InlineData("504006037")]
        [InlineData("507082389")]
        [InlineData("506740439")]
        public void CreateInstance_NotEmptyNif_InstanceCreated(string notEmptyNif)
        {
            Assert.DoesNotThrows(() =>
            {
                var nif = ActivatorHelper.CreateInstance<Nif>(notEmptyNif);
                Assert.NotNull(nif);
                Assert.Equal(notEmptyNif, nif.Value);
            });
        }

        [Fact]
        public void CreateInstance_DefaultDateOfBirth_InstanceCreated()
        {
            var defaultDateOfBirth = default(DateTime);

            Assert.DoesNotThrows(() =>
            {
                var dateOfBirth = ActivatorHelper.CreateInstance<DateOfBirthDummy>(defaultDateOfBirth);
                Assert.NotNull(dateOfBirth);
            });
        }

        [Fact]
        public void CreateInstance_NotDefaultDateOfBirth_InstanceCreated()
        {
            var notDefaultDateOfBirth = new DateTime(1990, 10, 20);

            Assert.DoesNotThrows(() =>
            {
                var dateOfBirth = ActivatorHelper.CreateInstance<DateOfBirthDummy>(notDefaultDateOfBirth);
                Assert.NotNull(dateOfBirth);
                Assert.Equal(notDefaultDateOfBirth, dateOfBirth.Value);
            });
        }
    }
}
