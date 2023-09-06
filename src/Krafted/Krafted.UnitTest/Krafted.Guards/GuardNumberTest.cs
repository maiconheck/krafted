using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
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
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(5, lessThan5));
            AssertMessage(ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(Convert.ToDecimal(5), lessThan5));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(Convert.ToDouble(5), lessThan5));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal($"Number cannot be less than {lessThan5}. (Parameter 'lessThan5')", actualMessage);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan(Convert.ToDouble(5), lessThan5, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'lessThan5')", ex4.Message);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void GuardAgainstLessThan5_EqualOrGreaterThan5_DoesNotThrowsException(int equalOrGreaterThan5)
        {
            Assert.DoesNotThrows(() => Guard.Against.LessThan(5, equalOrGreaterThan5));
            Assert.DoesNotThrows(() => Guard.Against.LessThan(Convert.ToDecimal(5), Convert.ToDecimal(equalOrGreaterThan5)));
            Assert.DoesNotThrows(() => Guard.Against.LessThan(Convert.ToDouble(5), Convert.ToDouble(equalOrGreaterThan5)));
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void GuardAgainstGreaterThan5_GreaterThan5_ThrowsException(int greaterThan5)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.GreaterThan(5, greaterThan5));
            Assert.Equal($"Number cannot be greater than {greaterThan5}. (Parameter 'greaterThan5')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.GreaterThan(5, greaterThan5, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'greaterThan5')", ex2.Message);
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
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(5, equalOrLessThan5));
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(Convert.ToDecimal(5), Convert.ToDecimal(equalOrLessThan5)));
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(Convert.ToDouble(5), Convert.ToDouble(equalOrLessThan5)));
        }

        [Fact]
        public void GuardAgainstZero_Zero_ThrowsException()
        {
            var zero = 0;

            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(zero));
            Assert.Equal("Number cannot be zero. (Parameter 'zero')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(Convert.ToDecimal(zero)));
            Assert.Equal("Number cannot be zero. (Parameter 'Convert.ToDecimal(zero)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(Convert.ToDouble(zero)));
            Assert.Equal("Number cannot be zero. (Parameter 'Convert.ToDouble(zero)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero(zero, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'zero')", ex4.Message);
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
            Assert.DoesNotThrows(() => Guard.Against.Zero(greaterOrLessThanZero));
            Assert.DoesNotThrows(() => Guard.Against.Zero(Convert.ToDecimal(greaterOrLessThanZero)));
            Assert.DoesNotThrows(() => Guard.Against.Zero(Convert.ToDouble(greaterOrLessThanZero)));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstNegative_Negative_ThrowsException(int negative)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(negative));
            Assert.Equal("Number cannot be negative. (Parameter 'negative')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(Convert.ToDecimal(negative)));
            Assert.Equal("Number cannot be negative. (Parameter 'Convert.ToDecimal(negative)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(Convert.ToDouble(negative)));
            Assert.Equal("Number cannot be negative. (Parameter 'Convert.ToDouble(negative)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative(Convert.ToDouble(negative), "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'Convert.ToDouble(negative)')", ex4.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstNegative_ZeroAndPositive_DoesNotThrowsException(int zeroAndPositive)
        {
            Assert.DoesNotThrows(() => Guard.Against.Negative(zeroAndPositive));
            Assert.DoesNotThrows(() => Guard.Against.Negative(Convert.ToDecimal(zeroAndPositive)));
            Assert.DoesNotThrows(() => Guard.Against.Negative(Convert.ToDouble(zeroAndPositive)));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstPositive_Positive_ThrowsException(int positive)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(positive));
            Assert.Equal("Number cannot be positive. (Parameter 'positive')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(Convert.ToDecimal(positive)));
            Assert.Equal("Number cannot be positive. (Parameter 'Convert.ToDecimal(positive)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(Convert.ToDouble(positive)));
            Assert.Equal("Number cannot be positive. (Parameter 'Convert.ToDouble(positive)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive(Convert.ToDouble(positive), "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'Convert.ToDouble(positive)')", ex4.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstPositive_ZeroAndNegative_DoesNotThrowsException(int zeroAndNegative)
        {
            Assert.DoesNotThrows(() => Guard.Against.Positive(zeroAndNegative));
            Assert.DoesNotThrows(() => Guard.Against.Positive(Convert.ToDecimal(zeroAndNegative)));
            Assert.DoesNotThrows(() => Guard.Against.Positive(Convert.ToDouble(zeroAndNegative)));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstZeroOrLess_ZeroOrLess_ThrowsException(int zeroOrLess)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess(zeroOrLess));
            AssertMessage("zeroOrLess", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess(Convert.ToDecimal(zeroOrLess)));
            AssertMessage("Convert.ToDecimal(zeroOrLess)", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess(Convert.ToDouble(zeroOrLess)));
            AssertMessage("Convert.ToDouble(zeroOrLess)", ex3.Message);

            void AssertMessage(string parameterName, string actualMessage)
            {
                if (zeroOrLess == 0)
                    Assert.Equal($"Number cannot be zero. (Parameter '{parameterName}')", actualMessage);
                else
                    Assert.Equal($"Number cannot be negative. (Parameter '{parameterName}')", actualMessage);
            }

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess(zeroOrLess, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'zeroOrLess')", ex4.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstZeroOrLess_Positive_DoesNotThrowsException(int positive)
        {
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(positive));
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(Convert.ToDecimal(positive)));
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(Convert.ToDouble(positive)));
        }
    }
}
