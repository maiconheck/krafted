using System;
using Krafted.Guards;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Guards.Br
{
    [Trait(nameof(UnitTest), "Krafted.Guards")]
    public class GuardBrTest
    {
        [Theory]
        [InlineData("50215505101")]
        [InlineData("ABCDEFGHI")]
        [InlineData("00855960054")]
        [InlineData("50740897923")]
        [InlineData("50362379745")]
        [InlineData("51042149778")]
        [InlineData("51042904752")]
        [InlineData("98042243712")]
        [InlineData("50682114732")]
        [InlineData("50712774785")]
        [InlineData("51052372796")]
        [InlineData("50062799715")]
        [InlineData("54262349751")]
        [InlineData("51112642746")]
        [InlineData("50462876798")]
        [InlineData("51052002775")]
        [InlineData("56242795756")]
        [InlineData("50542006755")]
        [InlineData("50542576767")]
        [InlineData("50402603778")]
        [InlineData("50702238796")]
        [InlineData("50672043755")]
        [InlineData("50402739744")]
        [InlineData("50702030707")]
        [InlineData("50352913778")]
        [InlineData("50392964794")]
        [InlineData("50212103712")]
        [InlineData("50052209756")]
        [InlineData("51472708778")]
        [InlineData("50592443794")]
        public void GuardAgainstInvalidCpf_InvalidCpf_ThrowsException(string invalidCpf)
        {
            var ex = Assert.Throws<FormatException>(() => Guard.Against.InvalidCpf(invalidCpf));
            Assert.Equal("Invalid CPF: {0}.".Format(invalidCpf), ex.Message);
        }

        [Fact]
        public void GuardAgainstInvalidCpf_InvalidCpfWithCustomMessage_ThrowsException()
        {
            var ex = Assert.Throws<FormatException>(() => Guard.Against.InvalidCpf("50592443794", "My custom error message."));
            Assert.Equal("My custom error message.", ex.Message);
        }

        [Theory]
        [InlineData("68509035008")]
        [InlineData("81941847030")]
        [InlineData("71257841009")]
        [InlineData("34718562007")]
        [InlineData("97983489072")]
        [InlineData("00874091004")]
        [InlineData("56638670077")]
        [InlineData("24251730054")]
        [InlineData("14704751546")]
        [InlineData("55119438350")]
        [InlineData("96765052348")]
        [InlineData("30047713577")]
        [InlineData("48159818840")]
        [InlineData("76549636531")]
        [InlineData("83396832760")]
        [InlineData("69336634186")]
        [InlineData("27329110701")]
        [InlineData("03525840764")]
        [InlineData("33921814472")]
        [InlineData("07287562340")]
        [InlineData("22076228519")]
        [InlineData("54225844064")]
        [InlineData("91375227602")]
        [InlineData("49358767944")]
        [InlineData("37273340375")]
        [InlineData("62885300779")]
        [InlineData("14979842038")]
        [InlineData("70531036090")]
        [InlineData("14874791077")]
        [InlineData("77109739066")]
        public void GuardAgainstInvalidCpf_ValidCpf_DoesNotThrows(string validCpf)
        {
            Assert.DoesNotThrows(() => Guard.Against.InvalidCpf(validCpf));
        }

        [Theory]
        [InlineData("50215505101425")]
        [InlineData("ABCDEFGHIJKLMN")]
        [InlineData("00855960054345")]
        [InlineData("50740897923574")]
        [InlineData("50362379745356")]
        [InlineData("51042149778235")]
        [InlineData("51042904752045")]
        [InlineData("98042243712255")]
        [InlineData("45582114732235")]
        [InlineData("50712774785563")]
        [InlineData("51052372796452")]
        [InlineData("50062799715655")]
        [InlineData("54262349655751")]
        [InlineData("51112676742746")]
        [InlineData("50462867476798")]
        [InlineData("51052005652775")]
        [InlineData("56242794345756")]
        [InlineData("50542008776755")]
        [InlineData("50542566746767")]
        [InlineData("50402676603778")]
        [InlineData("50702766238796")]
        [InlineData("50672055643755")]
        [InlineData("50402735659744")]
        [InlineData("50702030655707")]
        [InlineData("50352913766778")]
        [InlineData("50392976564794")]
        [InlineData("50212176403712")]
        [InlineData("50052767209756")]
        [InlineData("51472708656778")]
        [InlineData("50592443765694")]
        public void GuardAgainstInvalidCnpj_InvalidCnpj_ThrowsException(string invalidCnpj)
        {
            var ex = Assert.Throws<FormatException>(() => Guard.Against.InvalidCnpj(invalidCnpj));
            Assert.Equal("Invalid CNPJ: {0}.".Format(invalidCnpj), ex.Message);
        }

        [Fact]
        public void GuardAgainstInvalidCnpj_InvalidCnpjWithCustomMessage_ThrowsException()
        {
            var ex = Assert.Throws<FormatException>(() => Guard.Against.InvalidCnpj("50592443765694", "My custom error message."));
            Assert.Equal("My custom error message.", ex.Message);
        }

        [Theory]
        [InlineData("47158571894466")]
        [InlineData("60332990553951")]
        [InlineData("33751820087512")]
        [InlineData("09208037998207")]
        [InlineData("11539854265705")]
        [InlineData("08502556922150")]
        [InlineData("83595281334731")]
        [InlineData("64508174637760")]
        [InlineData("64399317207579")]
        [InlineData("10431568088298")]
        [InlineData("92478582439608")]
        [InlineData("37727744751860")]
        [InlineData("78446245664806")]
        [InlineData("39076004617439")]
        [InlineData("33478392045844")]
        [InlineData("83177988000196")]
        [InlineData("73430206000125")]
        [InlineData("07724590000144")]
        [InlineData("24920566000108")]
        [InlineData("72014834000167")]
        [InlineData("43220847000194")]
        [InlineData("75612898000158")]
        [InlineData("65448203000190")]
        [InlineData("47826982000139")]
        [InlineData("95761997000109")]
        [InlineData("60075672000198")]
        [InlineData("77218191000197")]
        [InlineData("83828473000109")]
        [InlineData("41915770000141")]
        [InlineData("36047281000185")]
        public void GuardAgainstInvalidCnpj_ValidCnpj_DoesNotThrows(string validCnpj)
        {
            Assert.DoesNotThrows(() => Guard.Against.InvalidCnpj(validCnpj));
        }
    }
}
