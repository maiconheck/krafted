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
        public void Result_SuccessT_OperationTValid()
        {
            var result = Result.Success("My value.");

            Assert.True(result.Value.Valid);
            Assert.False(result.Value.Invalid);
            Assert.True(result.HasValue);
            Assert.False(result.HasNoValue);
            Assert.Equal("My value.", result.Value.OperationValue);
            Assert.Equal(string.Empty, result.Value.InvalidReason);
        }

        [Fact]
        public void Result_FailureT_OperationInvalid()
        {
            var result1 = Result.Failure<string>("Fail for some reason.");

            Assert.False(result1.Value.Valid);
            Assert.True(result1.Value.Invalid);
            Assert.True(result1.HasValue);
            Assert.False(result1.HasNoValue);
            Assert.Null(result1.Value.OperationValue);
            Assert.Equal("Fail for some reason.", result1.Value.InvalidReason);
        }

        [Fact]
        public void Result_FailureT_OperationValueDefaultType()
        {
            var result2 = Result.Failure<Guid>("Fail for some reason.");
            Assert.Equal(Guid.Empty, result2.Value.OperationValue);
            Assert.Equal("Fail for some reason.", result2.Value.InvalidReason);

            var result3 = Result.Failure<int>("Fail for some reason.");
            Assert.Equal(0, result3.Value.OperationValue);
            Assert.Equal("Fail for some reason.", result3.Value.InvalidReason);

            var result4 = Result.Failure<bool>("Fail for some reason.");
            Assert.False(result4.Value.OperationValue);
            Assert.Equal("Fail for some reason.", result4.Value.InvalidReason);
        }

        [Fact]
        public void Maybe_Value_HasValue()
        {
            var result = Result.Maybe("My value.");
            Assert.True(result.HasValue);
            Assert.False(result.HasNoValue);
            Assert.Equal("My value.", result.Value);
        }

        [Fact]
        public void Maybe_NoValue_HasNoValue()
        {
            var result = Result.Maybe<string>(null);
            Assert.False(result.HasValue);
            Assert.True(result.HasNoValue);

            var ex = Assert.Throws<ArgumentNullException>(() => result.Value);
            Assert.Equal("Value cannot be null. (Parameter 'Value')", ex.Message);
        }
    }
}
