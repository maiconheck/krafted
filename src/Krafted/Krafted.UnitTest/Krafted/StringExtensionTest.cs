using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class StringExtensionTest
    {
        private const string _linkInput = @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>";
        private const string _linkPattern = @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)";

        private const string _emailInput = @"the foo@demo.net e-mail";
        private const string _emailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        private const string _hourInput = @"14:00 is the hour";
        private const string _hourPattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?";

        [Fact]
        public void Remove_Input_CorrectPattern_ShouldBeRemoved()
        {
            Assert.Equal("View all titles", _linkInput.Remove(_linkPattern));
            Assert.Equal("the  e-mail", _emailInput.Remove(_emailPattern));
            Assert.Equal(" is the hour", _hourInput.Remove(_hourPattern));
        }

        [Fact]
        public void Remove_Input_IncorrectPattern_ShouldNotBeRemoved()
        {
            Assert.Equal(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>", _linkInput.Remove(_hourPattern));
            Assert.Equal("the foo@demo.net e-mail", _emailInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
            Assert.Equal("14:00 is the hour", _hourInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
        }

        [Fact]
        public void Replace_Input_CorrectPattern_Replacement_ShouldBeReplaced()
        {
            Assert.Equal("ReplacedView all titlesReplaced", _linkInput.Replace(_linkPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("the Replaced e-mail", _emailInput.Replace(_emailPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("Replaced is the hour", _hourInput.Replace(_hourPattern, "Replaced", RegexOptions.Compiled));
        }

        [Fact]
        public void Replace_Input_IncorrectPattern_Replacement_ShouldNotBeReplaced()
        {
            Assert.Equal(
                @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>",
                _linkInput.Replace(_hourPattern, "Replaced", RegexOptions.Compiled));

            Assert.Equal("the foo@demo.net e-mail", _emailInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
            Assert.Equal("14:00 is the hour", _hourInput.Replace(@"\/\*[\s\S]*?\*\/|\/\/.*", "Replaced", RegexOptions.Compiled));
        }

        [Fact]
        public void Format_Input_Formated()
        {
            string input = "Replace {0} {1} in this {2}".Format("some", "words", "phrase");
            Assert.Equal("Replace some words in this phrase", input);
        }
    }
}
