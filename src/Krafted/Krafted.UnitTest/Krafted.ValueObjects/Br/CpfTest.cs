using System;
using Krafted.ValueObjects.Br;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects.Br
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class CpfTest
    {
        [Fact]
        public void NewCpf_Value_ProperInstantiated()
        {
            var cpf1 = new Cpf("99456008002");
            Assert.Equal("99456008002", cpf1.Value);
            Assert.Equal("99456008002", cpf1.ToString());

            var cpf2 = (Cpf)"99456008002";
            Assert.Equal("99456008002", cpf2.Value);
            Assert.Equal("99456008002", cpf2.ToString());

            var cpf3 = Cpf.NewCpf("99456008002");
            Assert.Equal("99456008002", cpf3.Value);
            Assert.Equal("99456008002", cpf3.ToString());
        }

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
        public void NewCpf_InvalidCpf_ThrowsException(string invalidCpf)
        {
            var ex1 = Assert.Throws<FormatException>(() => new Cpf(invalidCpf));
            Assert.Equal($"Invalid CPF: {invalidCpf}.", ex1.Message);

            var ex2 = Assert.Throws<FormatException>(() => (Cpf)invalidCpf);
            Assert.Equal($"Invalid CPF: {invalidCpf}.", ex2.Message);

            var ex3 = Assert.Throws<FormatException>(() => Cpf.NewCpf(invalidCpf));
            Assert.Equal($"Invalid CPF: {invalidCpf}.", ex3.Message);
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
        public void NewCpf_ValidCpf_DoesNotThrowsException(string validCpf)
        {
            Assert.DoesNotThrows(() => new Cpf(validCpf));
            Assert.DoesNotThrows(() => (Cpf)validCpf);
            Assert.DoesNotThrows(() => Cpf.NewCpf(validCpf));
        }

        [Theory]
        [InlineData("41559100044")]
        [InlineData("07575768009")]
        [InlineData("61263248039")]
        [InlineData("45817046008")]
        [InlineData("53430507006")]
        public void NewCpf_ToString_StringCpf(string cpf)
        {
            Assert.Equal(cpf, new Cpf(cpf).ToString());
            Assert.Equal(cpf, ((Cpf)cpf).ToString());
            Assert.Equal(cpf, Cpf.NewCpf(cpf).ToString());
        }

        [Theory]
        [InlineData("41559100044", "41559100044", false)]
        [InlineData("07575768009", "07575768009", false)]
        [InlineData("61263248039", "61263248039", false)]
        [InlineData("45817046008", "45817046008", false)]
        [InlineData("53430507006", "53430507006", false)]
        [InlineData("41559100044", "415.591.000-44", true)]
        [InlineData("07575768009", "075.757.680-09", true)]
        [InlineData("61263248039", "612.632.480-39", true)]
        [InlineData("45817046008", "458.170.460-08", true)]
        [InlineData("53430507006", "534.305.070-06", true)]
        public void NewCpf_ToStringMasked_StringCpf(string cpf, string expectedValue, bool masked)
        {
            Assert.Equal(expectedValue, new Cpf(cpf).ToString(masked));
            Assert.Equal(expectedValue, ((Cpf)cpf).ToString(masked));
            Assert.Equal(expectedValue, Cpf.NewCpf(cpf).ToString(masked));
        }
    }
}
