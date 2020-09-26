using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class GuardNumberTest
    {
        [Theory]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void GuardAgainstLessThan5_LessThan5_ThrowsException(int lessThan5)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(5, lessThan5, nameof(lessThan5)));
            AssertMessage(ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(Convert.ToDecimal(5), lessThan5, nameof(lessThan5)));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(Convert.ToDouble(5), lessThan5, nameof(lessThan5)));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal($"Parameter cannot be less than {lessThan5}. (Parameter 'lessThan5')", actualMessage);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void GuardAgainstLessThan5_EqualOrGreaterThan5_DoesNotThrowsException(int equalOrGreaterThan5)
        {
            Assert.DoesNotThrows(() => Guard.Against.LessThan(5, equalOrGreaterThan5, nameof(equalOrGreaterThan5)));
            Assert.DoesNotThrows(() => Guard.Against.LessThan(Convert.ToDecimal(5), Convert.ToDecimal(equalOrGreaterThan5), nameof(equalOrGreaterThan5)));
            Assert.DoesNotThrows(() => Guard.Against.LessThan(Convert.ToDouble(5), Convert.ToDouble(equalOrGreaterThan5), nameof(equalOrGreaterThan5)));
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void GuardAgainstGreaterThan5_GreaterThan5_ThrowsException(int greaterThan5)
        {
            var ex = Assert.Throws<ArgumentException>(() => Guard.Against.GreaterThan(5, greaterThan5, nameof(greaterThan5)));
            Assert.Equal($"Parameter cannot be greater than {greaterThan5}. (Parameter 'greaterThan5')", ex.Message);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void GuardAgainstGreaterThan5_EqualOrLessThan5_DoesNotThrowsException(int equalOrLessThan5)
        {
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(5, equalOrLessThan5, nameof(equalOrLessThan5)));
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(Convert.ToDecimal(5), Convert.ToDecimal(equalOrLessThan5), nameof(equalOrLessThan5)));
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(Convert.ToDouble(5), Convert.ToDouble(equalOrLessThan5), nameof(equalOrLessThan5)));
        }

        [Fact]
        public void GuardAgainstZero_Zero_ThrowsException()
        {
            var zero = 0;

            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(zero, nameof(zero)));
            AssertMessage(ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(Convert.ToDecimal(zero), nameof(zero)));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(Convert.ToDouble(zero), nameof(zero)));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal("Parameter cannot be zero. (Parameter 'zero')", actualMessage);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstZero_GreaterOrLessThanZero_DoesNotThrowsException(int greaterOrLessThanZero)
        {
            Assert.DoesNotThrows(() => Guard.Against.Zero(greaterOrLessThanZero, nameof(greaterOrLessThanZero)));
            Assert.DoesNotThrows(() => Guard.Against.Zero(Convert.ToDecimal(greaterOrLessThanZero), nameof(greaterOrLessThanZero)));
            Assert.DoesNotThrows(() => Guard.Against.Zero(Convert.ToDouble(greaterOrLessThanZero), nameof(greaterOrLessThanZero)));
        }
    }
}
