using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class StringExtensionTest
    {
        private const string LinkInput = @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>";
        private const string LinkPattern = @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)";

        private const string EmailInput = @"the foo@demo.net e-mail";
        private const string EmailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        private const string HourInput = @"14:00 is the hour";
        private const string HourPattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?";

        [Fact]
        public void Remove_Input_CorrectPattern_ShouldBeRemoved()
        {
            Assert.Equal("View all titles", LinkInput.Remove(LinkPattern));
            Assert.Equal("the  e-mail", EmailInput.Remove(EmailPattern));
            Assert.Equal(" is the hour", HourInput.Remove(HourPattern));
        }

        [Fact]
        public void Remove_Input_IncorrectPattern_ShouldNotBeRemoved()
        {
            Assert.Equal(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>", LinkInput.Remove(HourPattern));
            Assert.Equal("the foo@demo.net e-mail", EmailInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
            Assert.Equal("14:00 is the hour", HourInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
        }

        [Fact]
        public void Replace_Input_CorrectPattern_Replacement_ShouldBeReplaced()
        {
            Assert.Equal("ReplacedView all titlesReplaced", LinkInput.Replace(LinkPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("the Replaced e-mail", EmailInput.Replace(EmailPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("Replaced is the hour", HourInput.Replace(HourPattern, "Replaced", RegexOptions.Compiled));
        }

        [Fact]
        public void Replace_Input_IncorrectPattern_Replacement_ShouldNotBeReplaced()
        {
            Assert.Equal(
                @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>",
                LinkInput.Replace(HourPattern, "Replaced", RegexOptions.Compiled));

            Assert.Equal("the foo@demo.net e-mail", EmailInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
            Assert.Equal("14:00 is the hour", HourInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
        }
    }
}