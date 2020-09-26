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

            void AssertMessage(string actualMessage) => Assert.Equal($"Number cannot be less than {lessThan5}. (Parameter 'lessThan5')", actualMessage);
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
            Assert.Equal($"Number cannot be greater than {greaterThan5}. (Parameter 'greaterThan5')", ex.Message);
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

            void AssertMessage(string actualMessage) => Assert.Equal("Number cannot be zero. (Parameter 'zero')", actualMessage);
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

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstNegative_Negative_ThrowsException(int negative)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(negative, nameof(negative)));
            AssertMessage(ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(Convert.ToDecimal(negative), nameof(negative)));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(Convert.ToDouble(negative), nameof(negative)));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal("Number cannot be negative. (Parameter 'negative')", actualMessage);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstNegative_ZeroAndPositive_DoesNotThrowsException(int zeroAndPositive)
        {
            Assert.DoesNotThrows(() => Guard.Against.Negative(zeroAndPositive, nameof(zeroAndPositive)));
            Assert.DoesNotThrows(() => Guard.Against.Negative(Convert.ToDecimal(zeroAndPositive), nameof(zeroAndPositive)));
            Assert.DoesNotThrows(() => Guard.Against.Negative(Convert.ToDouble(zeroAndPositive), nameof(zeroAndPositive)));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstPositive_Positive_ThrowsException(int positive)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(positive, nameof(positive)));
            AssertMessage(ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(Convert.ToDecimal(positive), nameof(positive)));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(Convert.ToDouble(positive), nameof(positive)));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal("Number cannot be positive. (Parameter 'positive')", actualMessage);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstPositive_ZeroAndNegative_DoesNotThrowsException(int zeroAndNegative)
        {
            Assert.DoesNotThrows(() => Guard.Against.Positive(zeroAndNegative, nameof(zeroAndNegative)));
            Assert.DoesNotThrows(() => Guard.Against.Positive(Convert.ToDecimal(zeroAndNegative), nameof(zeroAndNegative)));
            Assert.DoesNotThrows(() => Guard.Against.Positive(Convert.ToDouble(zeroAndNegative), nameof(zeroAndNegative)));
        }
    }
}
