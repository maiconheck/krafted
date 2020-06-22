using System;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class ExceptionHelperTest
    {
        [Fact]
        public void ThrowIfNull_Null_ThrowsException()
        {
            var ex1 = Assert.Throws<ArgumentNullException>(() =>
            {
                object param = null;
                param.ThrowIfNull(nameof(param));
            });
            Assert.Equal("Value cannot be null. (Parameter 'param')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() =>
            {
                object param = null;
                ExceptionHelper.ThrowIfNull(() => param);
            });
            Assert.Equal("Value cannot be null. (Parameter 'param')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentNullException>(() => ExceptionHelper.ThrowIfNull(null));
            Assert.Equal("Value cannot be null. (Parameter 'param')", ex3.Message);
        }

        [Fact]
        public void ThrowIfAnyNull_Null_ThrowsException()
        {
            var ex3 = Assert.Throws<ArgumentNullException>(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = null;
                object param4 = null;
                ExceptionHelper.ThrowIfAnyNull(() => param1, () => param2, () => param3, () => param4);
            });
            Assert.Equal("Value cannot be null. (Parameter 'param3')", ex3.Message);
        }

        [Fact]
        public void ThrowIfNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                param.ThrowIfNull(nameof(param));
            });

            Assert.DoesNotThrows(() =>
            {
                object param = new object();
                ExceptionHelper.ThrowIfNull(() => param);
            });
        }

        [Fact]
        public void ThrowIfAnyNull_NotNull_DoesNotThrowsException()
        {
            Assert.DoesNotThrows(() =>
            {
                object param1 = new object();
                object param2 = new object();
                object param3 = new object();
                object param4 = new object();
                ExceptionHelper.ThrowIfAnyNull(() => param1, () => param2, () => param3, () => param4);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowIfNullOrEmpty_NullOrEmpty_ThrowsException(string param)
        {
            var ex = Assert.Throws<ArgumentException>(() => param.ThrowIfNullOrEmpty(nameof(param)));
            Assert.Equal("Value cannot be null or empty.\r\nParameter name: param", ex.Message);
        }

        [Fact]
        public void ThrowIfNullOrEmpty_NotNullOrEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => param.ThrowIfNullOrEmpty(nameof(param)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowIfNullOrWhiteSpace_NullOrWhiteSpace_ThrowsException(string param)
        {
            var ex = Assert.Throws<ArgumentException>(() => ExceptionHelper.ThrowIfNullOrWhiteSpace(param, nameof(param)));
            Assert.Equal("Value cannot be null, empty or white-space.\r\nParameter name: param", ex.Message);
        }

        [Fact]
        public void ThrowIfNullOrWhiteSpace_NotNullOrEmpty_DoesNotThrowsException()
        {
            string param = "value";
            Assert.DoesNotThrows(() => ExceptionHelper.ThrowIfNullOrWhiteSpace(param, nameof(param)));
        }
    }
}
