using System;
using System.Collections.Generic;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

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
                object myParam = null;
                Guard.Against.Null(myParam, nameof(myParam));
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = null;
                object param4 = null;

                Guard.Against
                    .Null(param1, nameof(param1))
                    .Null(param2, nameof(param2))
                    .Null(param3, nameof(param3))
                    .Null(param4, nameof(param4));
            });
            Assert.Equal("Parameter cannot be null. (Parameter 'param3')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                Guard.Against.Null(param, nameof(param));
            });

            Assert.DoesNotThrows(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = new object();
                object param4 = new object();

                Guard.Against
                    .Null(param1, nameof(param1))
                    .Null(param2, nameof(param2))
                    .Null(param3, nameof(param3))
                    .Null(param4, nameof(param4));
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GuardAgainstNullOrEmpty_NullOrEmpty_ThrowsException(string myParam)
        {
            var ex = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrEmpty(myParam, nameof(myParam)));
            Assert.Equal("Parameter cannot be null or empty. (Parameter 'myParam')", ex.Message);

            var emptyList = new List<int>();
            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrEmpty(emptyList, nameof(emptyList)));
            Assert.Equal("Parameter cannot be null or empty. (Parameter 'emptyList')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNullOrEmpty_NotEmpty_DoesNotThrowsException()
        {
            string param1 = "value";
            Assert.DoesNotThrows(() => Guard.Against.NullOrEmpty(param1, nameof(param1)));

            var notEmptyList = new List<int> { 1, 2, 3, 4 };
            Assert.DoesNotThrows(() => Guard.Against.NullOrEmpty(notEmptyList, nameof(notEmptyList)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GuardAgainstNullOrWhiteSpace_NullOrWhiteSpace_ThrowsException(string myParam)
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrWhiteSpace(myParam, nameof(myParam)));
            Assert.Equal("Parameter cannot be null, empty or consists exclusively of white-space characters. (Parameter 'myParam')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => Guard.Against.NullOrWhiteSpace(myParam, nameof(myParam), "My custom error message"));
            Assert.Equal("My custom error message (Parameter 'myParam')", ex2.Message);
        }

        [Fact]
        public void GuardAgainstNullOrWhiteSpace_NotEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => Guard.Against.NullOrWhiteSpace(param, nameof(param)));
            Assert.DoesNotThrows(() => Guard.Against.NullOrWhiteSpace(param, nameof(param), "My custom error message"));
        }
    }
}
