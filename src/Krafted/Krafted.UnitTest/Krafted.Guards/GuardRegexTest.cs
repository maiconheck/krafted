using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardRegexTest
    {
        [Theory]
        [InlineData(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\""></a>", @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)")]
        [InlineData(@"foo@demo.net", @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [InlineData(@"14:00", @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?")]
        public void GuardAgainstMatch_PatternMatched_ThrowsException(string myParam, string pattern)
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.Match(myParam, pattern, nameof(myParam)));

            // Throws with custom error message.
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.Match(myParam, pattern, nameof(myParam), message: "My custom error message 1."));
            Assert.Equal("My custom error message 1. (Parameter 'myParam')", ex1.Message);

            // Throws with custom exception type and error message.
            var ex2 = Assert.Throws<InvalidOperationException>(() => Guard.Against.Match<InvalidOperationException>(myParam, pattern, nameof(myParam), message: "My custom error message 2."));
            Assert.Equal("My custom error message 2.", ex2.Message);

            var ex3 = Assert.Throws<ApplicationException>(() => Guard.Against.Match<ApplicationException>(myParam, pattern, nameof(myParam), message: "My custom error message 3."));
            Assert.Equal("My custom error message 3.", ex3.Message);

            var ex4 = Assert.Throws<BadImageFormatException>(() => Guard.Against.Match<BadImageFormatException>(myParam, pattern, nameof(myParam), message: "My custom error message 4."));
            Assert.Equal("My custom error message 4.", ex4.Message);
        }

        [Theory]
        [InlineData(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\""></a>", @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?")]
        [InlineData(@"foo@demo.net", @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)")]
        [InlineData(@"14:00", @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public void GuardAgainstMatch_PatternNotMatched_DoesNotThrows(string myParam, string pattern)
        {
            Assert.DoesNotThrows(() => Guard.Against.Match(myParam, pattern, nameof(myParam)));
        }

        [Theory]
        [InlineData(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\""></a>", @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?")]
        [InlineData(@"foo@demo.net", @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)")]
        [InlineData(@"14:00", @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public void GuardAgainstNotMatch_PatternNotMatched_ThrowsException(string myParam, string pattern)
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.NotMatch(myParam, pattern, nameof(myParam)));

            // Throws with custom error message.
            var ex1 = Assert.Throws<ArgumentException>(() => Guard.Against.NotMatch(myParam, pattern, nameof(myParam), message: "My custom error message 1."));
            Assert.Equal("My custom error message 1. (Parameter 'myParam')", ex1.Message);

            // Throws with custom exception type and error message.
            var ex2 = Assert.Throws<InvalidOperationException>(() => Guard.Against.NotMatch<InvalidOperationException>(myParam, pattern, nameof(myParam), message: "My custom error message 2."));
            Assert.Equal("My custom error message 2.", ex2.Message);

            var ex3 = Assert.Throws<ApplicationException>(() => Guard.Against.NotMatch<ApplicationException>(myParam, pattern, nameof(myParam), message: "My custom error message 3."));
            Assert.Equal("My custom error message 3.", ex3.Message);

            var ex4 = Assert.Throws<BadImageFormatException>(() => Guard.Against.NotMatch<BadImageFormatException>(myParam, pattern, nameof(myParam), message: "My custom error message 4."));
            Assert.Equal("My custom error message 4.", ex4.Message);
        }

        [Theory]
        [InlineData(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\""></a>", @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)")]
        [InlineData(@"foo@demo.net", @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        [InlineData(@"14:00", @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?")]
        public void GuardAgainstNotMatch_PatternMatched_DoesNotThrows(string myParam, string pattern)
        {
            Assert.DoesNotThrows(() => Guard.Against.NotMatch(myParam, pattern, nameof(myParam)));
        }
    }
}
