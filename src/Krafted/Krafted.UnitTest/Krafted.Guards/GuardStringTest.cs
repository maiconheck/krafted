using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardStringTest
    {
        [Theory]
        [InlineData(1, "A")]
        [InlineData(2, "AB")]
        [InlineData(3, "ABC")]
        public void GuardAgainstExactLength_ExactLength_DoesNotThrows(uint length, string myParam)
        {
            Assert.DoesNotThrows(() => Guard.Against.Length(length, myParam));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("ABCD")]
        public void GuardAgainstExactLength_NotExactLength_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.Length(3, myParam));
            Assert.Equal("myParam must be length 3. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.Length(3, myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstExactLength_Null_DoesNotThrows()
        {
            string? myParam = null;
            Assert.DoesNotThrows(() => Guard.Against.Length(1, myParam));
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("ABC")]
        [InlineData("ABCD")]
        [InlineData("ABCDE")]
        public void GuardAgainstMinLengthMaxLength_MinLengthMaxLength_DoesNotThrows(string myParam)
        {
            Assert.DoesNotThrows(() => Guard.Against.Length(1, 5, myParam));
        }

        [Theory]
        [InlineData("ABCDEF")]
        [InlineData("ABCDEFG")]
        public void GuardAgainstMinLengthMaxLength_OutsideMinLengthMaxLength_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.Length(1, 5, myParam));
            Assert.Equal("myParam must be at least 1 character, and at most 5 characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.Against.Length(1, 5, myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstMinLengthMaxLength_Null_DoesNotThrows()
        {
            string? myParam = null;
            Assert.DoesNotThrows(() => Guard.Against.Length(1, 5, myParam));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("A")]
        [InlineData("AB")]
        [InlineData("ABC")]
        [InlineData("ABCD")]
        [InlineData("ABCDE")]
        public void GuardAgainstMaxLength_MaxLength_DoesNotThrows(string myParam)
        {
            Assert.DoesNotThrows(() => Guard.Against.MaxLength(5, myParam));
        }

        [Theory]
        [InlineData("ABCDEF")]
        [InlineData("ABCDEFG")]
        public void GuardAgainstMaxLength_OutsideMaxLength_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.MaxLength(5, myParam));
            Assert.Equal("myParam must be at most 5 characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.MaxLength(5, myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstMaxLength_Null_DoesNotThrows()
        {
            string? myParam = null;
            Assert.DoesNotThrows(() => Guard.Against.MaxLength(5, myParam));
        }

        [Theory]
        [InlineData("ABC")]
        [InlineData("ABCD")]
        [InlineData("ABCDE")]
        public void GuardAgainstMinLength_MinLength_DoesNotThrows(string myParam)
        {
            Assert.DoesNotThrows(() => Guard.Against.MinLength(3, myParam));
        }

        [Theory]
        [InlineData("AB")]
        [InlineData("A")]
        [InlineData(" ")]
        public void GuardAgainstMinLength_OutsideMinLength_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.MinLength(3, myParam));
            Assert.Equal("myParam must be at least 3 characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.MinLength(3, myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstMinLength_Null_DoesNotThrows()
        {
            string? myParam = null;
            Assert.DoesNotThrows(() => Guard.Against.MinLength(3, myParam));
        }
    }
}
