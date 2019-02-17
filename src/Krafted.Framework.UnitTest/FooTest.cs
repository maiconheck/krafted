using System;
using Xunit;
using Krafted.Framework.IntegrationTest.FooBar.Domain;

namespace Krafted.Framework.UnitTest.Domain
{
    [Trait(nameof(UnitTest), nameof(Foo))]
    public class FooTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("nome longo, contendo mais do que cinquenta caracteres")]
        public void Foo_InvalidDescription_Invalid(string description)
        {
            var foo = new Foo(description, new DateTime(), new DateTime().AddDays(1));
            Assert.True(foo.Invalid);
            Assert.Equal(3, foo.Notifications.Count);
        }

        [Theory]
        [InlineData("abcde")]
        [InlineData("a nome deve ter pelo menos cinco caracteres")]
        public void Foo_ValidDescription_Valid(string description)
        {
            var foo = new Foo(description, new DateTime(1980,1 ,2), new DateTime(1980, 1, 2).AddDays(1));
            Assert.True(foo.Valid);
            Assert.Equal(0, foo.Notifications.Count);
        }

        [Fact]
        public void Foo_InvalidDates_Invalid()
        {
            var foo = new Foo("abcde", new DateTime(1970, 1 ,1), new DateTime(1970, 1, 1));
            Assert.True(foo.Invalid);
            Assert.Equal(3, foo.Notifications.Count);

            foo = new Foo("abcde", new DateTime(2000, 1, 1), new DateTime(1999, 1, 1));
            Assert.True(foo.Invalid);
            Assert.Equal(1, foo.Notifications.Count);
        }

        [Fact]
        public void Foo_ValidDates_Valid()
        {
            var foo = new Foo("abcde", new DateTime(1980, 1, 2), new DateTime(1980, 1, 3));
            Assert.True(foo.Valid);
            Assert.Equal(0, foo.Notifications.Count);
        }
    }
}
