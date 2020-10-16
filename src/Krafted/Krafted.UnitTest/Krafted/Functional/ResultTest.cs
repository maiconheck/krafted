using System;
using Krafted.Functional;
using Xunit;

namespace Krafted.UnitTest.Krafted.Functional
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class ResultTest
    {
        [Fact]
        public void Result_Success_OperationValid()
        {
            var result = Result.Success();

            Assert.True(result.Value.Valid);
            Assert.False(result.Value.Invalid);
            Assert.True(result.HasValue);
            Assert.False(result.HasNoValue);
            Assert.Equal(string.Empty, result.Value.InvalidReason);
        }

        [Fact]
        public void Result_Failure_OperationInvalid()
        {
            var result = Result.Failure("Fail for some reason.");

            Assert.False(result.Value.Valid);
            Assert.True(result.Value.Invalid);
            Assert.True(result.HasValue);
            Assert.False(result.HasNoValue);
            Assert.Equal("Fail for some reason.", result.Value.InvalidReason);
        }

        [Fact]
        public void Result_SuccessT_OperationValid()
        {
            var result = Result.Success("My value.");

            Assert.True(result.HasValue);
            Assert.False(result.HasNoValue);
            Assert.Equal("My value.", result.Value);
        }

        [Fact]
        public void Result_FailureT_OperationInvalid()
        {
            var result = Result.Failure<string>();

            Assert.False(result.HasValue);
            Assert.True(result.HasNoValue);
            var ex = Assert.Throws<ArgumentNullException>(() => result.Value);
            Assert.Equal("Value cannot be null. (Parameter 'Value')", ex.Message);
        }
    }
}
