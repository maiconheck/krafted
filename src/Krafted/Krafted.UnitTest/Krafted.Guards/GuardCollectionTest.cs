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
        public void GuardAgainstEmpty_Empty_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int>();
                Guard.Against.Empty(myCollection, nameof(myCollection));
            });
            Assert.Equal("Collection cannot be empty. (Parameter 'myCollection')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int>();
                Guard.Against.Empty(myCollection, nameof(myCollection), "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myCollection')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstEmpty_NotEmpty_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myCollection1 = new List<int> { 1 };
                Guard.Against.Empty(myCollection1, nameof(myCollection1));

                var myCollection2 = new List<string> { "A" };
                Guard.Against.Empty(myCollection1, nameof(myCollection2));
            });
        }

        [Fact]
        public void GuardAgainstNotEmpty_NotEmpty_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int> { 1 };
                Guard.Against.NotEmpty(myCollection, nameof(myCollection));
            });
            Assert.Equal("Collection should be empty. (Parameter 'myCollection')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() =>
            {
                var myCollection = new List<int> { 1 };
                Guard.Against.NotEmpty(myCollection, nameof(myCollection), "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myCollection')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNotEmpty_Empty_DoesNotThrows()
        {
            Assert.DoesNotThrows(() =>
            {
                var myCollection1 = new List<int>();
                Guard.Against.NotEmpty(myCollection1, nameof(myCollection1));

                var myCollection2 = new List<string>();
                Guard.Against.NotEmpty(myCollection1, nameof(myCollection2));
            });
        }
    }
}
