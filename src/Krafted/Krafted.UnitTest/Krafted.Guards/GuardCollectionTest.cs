using System;
using System.Collections.Generic;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardCollectionTest
    {
        [Fact]
        public void GuardAgainstNotAny_NotAny_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int>();
                Guard.Against.NotAny(myCollection);
            });
            Assert.Equal("Collection cannot be empty. (Parameter 'myCollection')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int>();
                Guard.Against.NotAny(myCollection, "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myCollection')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNotAny_Any_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myCollection1 = new List<int> { 1 };
                Guard.Against.NotAny(myCollection1);

                var myCollection2 = new List<string> { "A" };
                Guard.Against.NotAny(myCollection1);
            });
        }

        [Fact]
        public void GuardAgainstNotAny_Null_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                List<int>? myCollection = null;
                Guard.Against.NotAny(myCollection);
            });
        }

        [Fact]
        public void GuardAgainstAny_Any_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int> { 1 };
                Guard.Against.Any(myCollection);
            });
            Assert.Equal("Collection should be empty. (Parameter 'myCollection')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int> { 1 };
                Guard.Against.Any(myCollection, "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myCollection')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstAny_NotAny_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myCollection1 = new List<int>();
                Guard.Against.Any(myCollection1, nameof(myCollection1));

                var myCollection2 = new List<string>();
                Guard.Against.Any(myCollection1, nameof(myCollection2));
            });
        }

        [Fact]
        public void GuardAgainstAny_Null_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                List<int>? myCollection = null;
                Guard.Against.Any(myCollection);
            });
        }
    }
}
