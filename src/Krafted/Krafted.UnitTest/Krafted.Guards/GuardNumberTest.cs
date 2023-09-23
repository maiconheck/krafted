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

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan<decimal>(Convert.ToDecimal(5), lessThan5));
            AssertMessage(ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan<double>(Convert.ToDouble(5), lessThan5));
            AssertMessage(ex3.Message);

            void AssertMessage(string actualMessage) => Assert.Equal($"Number cannot be less than {lessThan5}. (Parameter 'lessThan5')", actualMessage);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.LessThan<double>(Convert.ToDouble(5), lessThan5, "My custom error message."));
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

        [Fact]
        public void GuardAgainstLessThan_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.LessThan(number1, 1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.LessThan(number2, 1));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.LessThan(number3, 1));
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
        public void GuardAgainstGreaterThan_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(number1, 1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(number2, 1));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.GreaterThan(number3, 1));
        }

        [Fact]
        public void GuardAgainstZero_Zero_ThrowsException()
        {
            var zero = 0;

            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero<int>(zero));
            Assert.Equal("Number cannot be zero. (Parameter 'zero')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero<decimal>(Convert.ToDecimal(zero)));
            Assert.Equal("Number cannot be zero. (Parameter 'Convert.ToDecimal(zero)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero<double>(Convert.ToDouble(zero)));
            Assert.Equal("Number cannot be zero. (Parameter 'Convert.ToDouble(zero)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Zero<int>(zero, "My custom error message."));
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
            Assert.DoesNotThrows(() => Guard.Against.Zero<int>(greaterOrLessThanZero));
            Assert.DoesNotThrows(() => Guard.Against.Zero<decimal>(Convert.ToDecimal(greaterOrLessThanZero)));
            Assert.DoesNotThrows(() => Guard.Against.Zero<double>(Convert.ToDouble(greaterOrLessThanZero)));
        }

        [Fact]
        public void GuardAgainstZero_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.Zero(number1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.Zero(number2));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.Zero(number3));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstNegative_Negative_ThrowsException(int negative)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative<int>(negative));
            Assert.Equal("Number cannot be negative. (Parameter 'negative')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative<decimal>(Convert.ToDecimal(negative)));
            Assert.Equal("Number cannot be negative. (Parameter 'Convert.ToDecimal(negative)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative<double>(Convert.ToDouble(negative)));
            Assert.Equal("Number cannot be negative. (Parameter 'Convert.ToDouble(negative)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Negative<double>(Convert.ToDouble(negative), "My custom error message."));
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
            Assert.DoesNotThrows(() => Guard.Against.Negative<int>(zeroAndPositive));
            Assert.DoesNotThrows(() => Guard.Against.Negative<decimal>(Convert.ToDecimal(zeroAndPositive)));
            Assert.DoesNotThrows(() => Guard.Against.Negative<double>(Convert.ToDouble(zeroAndPositive)));
        }

        [Fact]
        public void GuardAgainstNegative_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.Negative(number1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.Negative(number2));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.Negative(number3));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstPositive_Positive_ThrowsException(int positive)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive<int>(positive));
            Assert.Equal("Number cannot be positive. (Parameter 'positive')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive<decimal>(Convert.ToDecimal(positive)));
            Assert.Equal("Number cannot be positive. (Parameter 'Convert.ToDecimal(positive)')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive<double>(Convert.ToDouble(positive)));
            Assert.Equal("Number cannot be positive. (Parameter 'Convert.ToDouble(positive)')", ex3.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.Positive<double>(Convert.ToDouble(positive), "My custom error message."));
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
            Assert.DoesNotThrows(() => Guard.Against.Positive<int>(zeroAndNegative));
            Assert.DoesNotThrows(() => Guard.Against.Positive<decimal>(Convert.ToDecimal(zeroAndNegative)));
            Assert.DoesNotThrows(() => Guard.Against.Positive<double>(Convert.ToDouble(zeroAndNegative)));
        }

        [Fact]
        public void GuardAgainstPositive_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.Positive(number1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.Positive(number2));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.Positive(number3));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void GuardAgainstZeroOrLess_ZeroOrLess_ThrowsException(int zeroOrLess)
        {
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess<int>(zeroOrLess));
            AssertMessage("zeroOrLess", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess<decimal>(Convert.ToDecimal(zeroOrLess)));
            AssertMessage("Convert.ToDecimal(zeroOrLess)", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess<double>(Convert.ToDouble(zeroOrLess)));
            AssertMessage("Convert.ToDouble(zeroOrLess)", ex3.Message);

            void AssertMessage(string parameterName, string actualMessage)
            {
                if (zeroOrLess == 0)
                    Assert.Equal($"Number cannot be zero. (Parameter '{parameterName}')", actualMessage);
                else
                    Assert.Equal($"Number cannot be negative. (Parameter '{parameterName}')", actualMessage);
            }

            var ex4 = Assert.Throws<ArgumentException>(() => Guard.Against.ZeroOrLess<int>(zeroOrLess, "My custom error message."));
            Assert.Equal("My custom error message. (Parameter 'zeroOrLess')", ex4.Message);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GuardAgainstZeroOrLess_Positive_DoesNotThrowsException(int positive)
        {
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess<int>(positive));
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess<decimal>(Convert.ToDecimal(positive)));
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess<double>(Convert.ToDouble(positive)));
        }

        [Fact]
        public void GuardAgainstZeroOrLess_Null_DoesNotThrowsException()
        {
            int? number1 = null;
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(number1));

            decimal? number2 = null;
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(number2));

            double? number3 = null;
            Assert.DoesNotThrows(() => Guard.Against.ZeroOrLess(number3));
        }
    }
}
