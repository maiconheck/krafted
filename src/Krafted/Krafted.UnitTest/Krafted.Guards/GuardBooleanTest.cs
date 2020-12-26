using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardBooleanTest
    {
        [Fact]
        public void GuardAgainstTrue_True_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                bool myParam = true;
                Guard.Against.True(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be true. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                string myParam = "abc";
                Guard.Against.True(_ => myParam == "abc");
            });
            Assert.Equal("Predicate cannot be true.", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() =>
            {
                string myParam = "abc";
                Guard.Against.True(_ => myParam == "abc", nameof(myParam));
            });
            Assert.Equal("Predicate cannot be true. (Parameter 'myParam')", ex3.Message);
        }

        [Fact]
        public void GuardAgainstTrue_False_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                bool myParam = false;
                Guard.Against.True(myParam, nameof(myParam));
                Guard.Against.True(_ => "a" == "b", nameof(myParam));
            });
        }

        [Fact]
        public void GuardAgainstFalse_False_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                bool myParam = false;
                Guard.Against.False(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be false. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                string myParam = "abc";
                Guard.Against.False(_ => myParam == "a");
            });
            Assert.Equal("Predicate cannot be false.", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() =>
            {
                string myParam = "abc";
                Guard.Against.False(_ => myParam == "a", nameof(myParam));
            });
            Assert.Equal("Predicate cannot be false. (Parameter 'myParam')", ex3.Message);
        }

        [Fact]
        public void GuardAgainstFalse_True_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                bool myParam = true;
                Guard.Against.False(myParam, nameof(myParam));
                Guard.Against.False(_ => "ab" == "ab", nameof(myParam));
            });
        }
    }
}
