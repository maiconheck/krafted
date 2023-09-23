using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardNullTest
    {
        [Fact]
        public void GuardAgainstNull_Null_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() =>
            {
                object? myParam = null;
                Guard.Against.Null(myParam);
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object? param3 = null;
                object? param4 = null;

                Guard.Against
                    .Null(param1)
                    .Null(param2)
                    .Null(param3)
                    .Null(param4);
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'param3')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentNullException>(() =>
            {
                object? myParam = null;
                Guard.Against.Null(myParam, "My custom error message.");
            });
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex3.Message);
        }

        [Fact]
        public void GuardAgainstNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                Guard.Against.Null(param);
                Guard.Against.Null(param, "My custom error message.");
            });

            Assert.DoesNotThrows(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = new object();
                object param4 = new object();

                Guard.Against
                    .Null(param1)
                    .Null(param2)
                    .Null(param3)
                    .Null(param4);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GuardAgainstNullOrEmpty_NullOrEmpty_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrEmpty(myParam));
            Assert.Equal("Parameter cannot be null or empty. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrEmpty(myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNullOrEmpty_NotEmpty_DoesNotThrowsException()
        {
            string param1 = "value";
            Assert.DoesNotThrows(() => Guard.Against.NullOrEmpty(param1));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GuardAgainstNullOrWhiteSpace_NullOrWhiteSpace_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrWhiteSpace(myParam));
            Assert.Equal("Parameter cannot be null, empty or consists exclusively of white-space characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrWhiteSpace(myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNullOrWhiteSpace_NotEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => Guard.Against.NullOrWhiteSpace(param));
            Assert.DoesNotThrows(() => Guard.Against.NullOrWhiteSpace(param, "My custom error message"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void GuardAgainstEmptyOrWhiteSpace_EmptyOrWhiteSpace_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.EmptyOrWhiteSpace(myParam));
            Assert.Equal("Parameter cannot be empty or consists exclusively of white-space characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.EmptyOrWhiteSpace(myParam, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstEmptyOrWhiteSpace_NotEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => Guard.Against.EmptyOrWhiteSpace(param));
            Assert.DoesNotThrows(() => Guard.Against.EmptyOrWhiteSpace(param, "My custom error message"));
        }

        [Fact]
        public void GuardAgainstEmptyOrWhiteSpace_Null_DoesNotThrowsException()
        {
            string? param = null;
            Assert.DoesNotThrows(() => Guard.Against.EmptyOrWhiteSpace(param));
        }
    }
}
