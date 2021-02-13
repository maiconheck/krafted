using System;
using System.Text.RegularExpressions;
using Xunit;

namespace Krafted.UnitTest.Krafted.Extensions
{
    [Trait(nameof(UnitTest), "Krafted.Extensions")]
    public class StringExtensionTest
    {
        private const string _linkInput = @"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>";
        private const string _linkPattern = @"(<script(\s|\S)*?<\/script>)|(<style(\s|\S)*?<\/style>)|(<!--(\s|\S)*?-->)|(<\/?(\s|\S)*?>)";

        private const string _emailInput = @"the foo@demo.net e-mail";
        private const string _emailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        private const string _hourInput = @"14:00 is the hour";
        private const string _hourPattern = @"([01]?[0-9]|2[0-3]):[0-5][0-9](:[0-5][0-9])?";

        [Fact]
        public void Remove_InputCorrectPattern_Removed()
        {
            Assert.Equal("View all titles", _linkInput.Remove(_linkPattern));
            Assert.Equal("the  e-mail", _emailInput.Remove(_emailPattern));
            Assert.Equal(" is the hour", _hourInput.Remove(_hourPattern));
        }

        [Fact]
        public void Remove_InputIncorrectPattern_NotRemoved()
        {
            Assert.Equal(@"<a href=\""ViewAllTitlesQuickSearch.aspx?val=2&amp;val1=2171&amp;val65=2171\"">View all titles</a>", _linkInput.Remove(_hourPattern));
            Assert.Equal("the foo@demo.net e-mail", _emailInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
            Assert.Equal("14:00 is the hour", _hourInput.Remove(@"\/\*[\s\S]*?\*\/|\/\/.*"));
        }

        [Fact]
        public void Replace_InputCorrectPattern_ReplacementReplaced()
        {
            Assert.Equal("ReplacedView all titlesReplaced", _linkInput.Replace(_linkPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("the Replaced e-mail", _emailInput.Replace(_emailPattern, "Replaced", RegexOptions.Compiled));
            Assert.Equal("Replaced is the hour", _hourInput.Replace(_hourPattern, "Replaced", RegexOptions.Compiled));
        }

        [Fact]
        public void Replace_InputIncorrectPattern_ReplacementNotReplaced()
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

        [Fact]
        public void EncodeToBase64String_Input_Base64StringEncoded()
        {
            string plainString = "A clean, simple and extensible, carefully crafted set of libraries for general purpose.";
            string base64String = plainString.EncodeToBase64String();

            Assert.Equal("QSBjbGVhbiwgc2ltcGxlIGFuZCBleHRlbnNpYmxlLCBjYXJlZnVsbHkgY3JhZnRlZCBzZXQgb2YgbGlicmFyaWVzIGZvciBnZW5lcmFsIHB1cnBvc2Uu", base64String);
        }

        [Fact]
        public void DecodeFromBase64String_Input_Base64StringDecoded()
        {
            string base64String = "QSBjbGVhbiwgc2ltcGxlIGFuZCBleHRlbnNpYmxlLCBjYXJlZnVsbHkgY3JhZnRlZCBzZXQgb2YgbGlicmFyaWVzIGZvciBnZW5lcmFsIHB1cnBvc2Uu";
            string plainString = base64String.DecodeFromBase64String();

            Assert.Equal("A clean, simple and extensible, carefully crafted set of libraries for general purpose.", plainString);
        }

        [Theory]
        [InlineData("Escolhe um trabalho de que gostes, e não terás que trabalhar nem um dia na tua vida.", "escolhe-um-trabalho-de-que-gostes-e-nao-teras-que-trabalhar-nem-um-dia-na-tua-vida")] // - Confúcio
        [InlineData("A vida vai ficando cada vez mais dura perto do topo", "a-vida-vai-ficando-cada-vez-mais-dura-perto-do-topo")] // - Nietzsche
        [InlineData("O sucesso normalmente vem para quem está ocupado demais para procurar por ele", "o-sucesso-normalmente-vem-para-quem-esta-ocupado-demais-para-procurar-por-ele")] // – Henry David Thoreau
        [InlineData("Eu não falhei. Só descobri 10 mil caminhos que não eram o certo", "eu-nao-falhei-so-descobri-10-mil-caminhos-que-nao-eram-o-certo")] // - Thomas Edison
        [InlineData("Ouse ir além, ouse fazer diferente e o poder lhe será dado!", "ouse-ir-alem-ouse-fazer-diferente-e-o-poder-lhe-sera-dado")] // - José Roberto Marques
        [InlineData("A persistência é o caminho do êxito", "a-persistencia-e-o-caminho-do-exito")] // - Charles Chaplin
        public void ToSlug_InputMaxLength300_Slug(string input, string expectedSlug)
        {
            Assert.Equal(expectedSlug, input.ToSlug(maxLength: 300));
        }

        [Theory]
        [InlineData("Escolhe um trabalho de que gostes, e não terás que trabalhar nem um dia na tua vida.", "escolhe-um-trabalho-de-que-gostes-e-nao-teras-que-trabalhar")] // - Confúcio
        [InlineData("Eu não falhei. Só descobri 10 mil caminhos que não eram o certo", "eu-nao-falhei-so-descobri-10-mil-caminhos-que-nao-eram-o-cer")] // - Thomas Edison
        [InlineData("O sucesso normalmente vem para quem está ocupado demais para procurar por ele", "o-sucesso-normalmente-vem-para-quem-esta-ocupado-demais-para")] // – Henry David Thoreau
        public void ToSlug_InputLengthDefault60_Slug(string input, string expectedSlug)
        {
            Assert.Equal(expectedSlug, input.ToSlug());
        }
    }
}
