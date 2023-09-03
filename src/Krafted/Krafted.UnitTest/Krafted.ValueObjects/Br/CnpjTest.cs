using System;
using Krafted.ValueObjects.Br;
using Xunit;
using Assert = Krafted.UnitTests.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.ValueObjects.Br
{
    [Trait(nameof(UnitTest), "Krafted.ValueObjects")]
    public class CnpjTest
    {
        [Fact]
        public void NewCnpj_Value_ProperInstantiated()
        {
            var cnpj1 = new Cnpj("47158571894466");
            Assert.Equal("47158571894466", cnpj1.Value);
            Assert.Equal("47158571894466", cnpj1.ToString());

            var cnpj2 = (Cnpj)"47158571894466";
            Assert.Equal("47158571894466", cnpj2.Value);
            Assert.Equal("47158571894466", cnpj2.ToString());

            var cnpj3 = Cnpj.NewCnpj("47158571894466");
            Assert.Equal("47158571894466", cnpj3.Value);
            Assert.Equal("47158571894466", cnpj3.ToString());
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
        public void NewCnpj_InvalidCnpj_ThrowsException(string invalidCnpj)
        {
            var ex1 = Assert.Throws<FormatException>(() => new Cnpj(invalidCnpj));
            Assert.Equal($"Invalid CNPJ: {invalidCnpj}.", ex1.Message);

            var ex2 = Assert.Throws<FormatException>(() => (Cnpj)invalidCnpj);
            Assert.Equal($"Invalid CNPJ: {invalidCnpj}.", ex2.Message);

            var ex3 = Assert.Throws<FormatException>(() => Cnpj.NewCnpj(invalidCnpj));
            Assert.Equal($"Invalid CNPJ: {invalidCnpj}.", ex3.Message);
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
        public void NewCnpj_ValidCnpj_DoesNotThrowsException(string validCnpj)
        {
            Assert.DoesNotThrows(() => new Cnpj(validCnpj));
            Assert.DoesNotThrows(() => (Cnpj)validCnpj);
            Assert.DoesNotThrows(() => Cnpj.NewCnpj(validCnpj));
        }

        [Theory]
        [InlineData("47158571894466")]
        [InlineData("60332990553951")]
        [InlineData("33751820087512")]
        [InlineData("09208037998207")]
        [InlineData("11539854265705")]
        public void NewCnpj_ToString_StringCnpj(string cnpj)
        {
            Assert.Equal(cnpj, new Cnpj(cnpj).ToString());
            Assert.Equal(cnpj, ((Cnpj)cnpj).ToString());
            Assert.Equal(cnpj, Cnpj.NewCnpj(cnpj).ToString());
        }

        [Theory]
        [InlineData("74940069886466", "74940069886466", false)]
        [InlineData("01995652390454", "01995652390454", false)]
        [InlineData("11934215102365", "11934215102365", false)]
        [InlineData("78153348126398", "78153348126398", false)]
        [InlineData("51338803475203", "51338803475203", false)]
        [InlineData("15251486999636", "15.251.486/9996-36", true)]
        [InlineData("66230831894240", "66.230.831/8942-40", true)]
        [InlineData("87717319422708", "87.717.319/4227-08", true)]
        [InlineData("23423628293011", "23.423.628/2930-11", true)]
        [InlineData("13995256208705", "13.995.256/2087-05", true)]
        public void NewCnpj_ToStringMasked_StringCnpj(string cnpj, string expectedValue, bool masked)
        {
            Assert.Equal(expectedValue, new Cnpj(cnpj).ToString(masked));
            Assert.Equal(expectedValue, ((Cnpj)cnpj).ToString(masked));
            Assert.Equal(expectedValue, Cnpj.NewCnpj(cnpj).ToString(masked));
        }
    }
}
