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
