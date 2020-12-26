// A attribute to replace the CurrentCulture with another culture.
//
// This class was obtained from the Xunit samples.
// Source: https://raw.githubusercontent.com/xunit/samples.xunit/main/UseCulture/UseCultureAttributeTests.cs
// Retrieved in November 2020.

using System;
using System.Globalization;
using System.Threading;
using Krafted.UnitTest.Xunit;
using Xunit;
using Xunit.Sdk;

namespace Krafted.UnitTest.Krafted.UnitTests.Xunit
{
    [Trait(nameof(UnitTest), "Krafted.UnitTests.Xunit")]
    public class UseCultureAttributeTest
    {
        [Fact]
        public void GuardClauses()
        {
            Assert.Throws<ArgumentNullException>(() => new UseCultureAttribute(null).Culture);
            Assert.Throws<ArgumentNullException>(() => new UseCultureAttribute("en-US", null).UICulture);
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("da-DK")]
        [InlineData("de-DE")]
        public void CreatingWithCultureSetsCorrectCultureProperty(string culture)
        {
            var attr = new UseCultureAttribute(culture);

            Assert.Equal(culture, attr.Culture.Name);
        }

        [Theory]
        [InlineData("nl-BE")]
        [InlineData("fi-FI")]
        [InlineData("fr-CA")]
        public void CreatingWithCultureAndUICultureSetsCorrectCulturePropery(string culture)
        {
            var attr = new UseCultureAttribute(culture, "fr");

            Assert.Equal(culture, attr.Culture.Name);
        }

        [Theory]
        [InlineData("fr-FR")]
        [InlineData("es-ES")]
        [InlineData("zh-HK")]
        public void CreatingWithCultureSetsSameUICulture(string culture)
        {
            var attr = new UseCultureAttribute(culture);

            Assert.Equal(culture, attr.UICulture.Name);
        }

        [Theory]
        [InlineData("nl-NL")]
        [InlineData("de-AT")]
        [InlineData("en-GB")]
        public void CreatingWithCultureAndUICultureSetsCorrectUICulturePropery(string uiCulture)
        {
            var attr = new UseCultureAttribute("el-GR", uiCulture);

            Assert.Equal(uiCulture, attr.UICulture.Name);
        }

        [Fact]
        public void IsBeforeAfterAttribute()
        {
            Assert.IsAssignableFrom<BeforeAfterTestAttribute>(new UseCultureAttribute("ga-IE"));
        }

        [Theory]
        [InlineData("it-IT")]
        [InlineData("ja-JP")]
        [InlineData("nb-NO")]
        public void CultureIsChangedWithinTest(string culture)
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            var attr = new UseCultureAttribute(culture);

            attr.Before(null);

            Assert.Equal(attr.Culture, Thread.CurrentThread.CurrentCulture);

            attr.After(null);

            Assert.Equal(originalCulture, Thread.CurrentThread.CurrentCulture);
        }

        [Theory]
        [InlineData("pt-BR")]
        [InlineData("pa-IN")]
        [InlineData("rm-CH")]
        public void UICultureIsChangedWithinTest(string uiCulture)
        {
            var originalUICulture = Thread.CurrentThread.CurrentUICulture;
            var attr = new UseCultureAttribute("ru-RU", uiCulture);

            attr.Before(null);

            Assert.Equal(attr.UICulture, Thread.CurrentThread.CurrentUICulture);

            attr.After(null);

            Assert.Equal(originalUICulture, Thread.CurrentThread.CurrentUICulture);
        }

        [Fact]
        [UseCulture("sv-SE")]
        public void AttributeChangesCultureToSwedishInTestMethod()
        {
            Assert.Equal("sv-SE", Thread.CurrentThread.CurrentCulture.Name);
        }

        [Fact]
        [UseCulture("th-TH", "es-CL")]
        public void AttributeChangesUICultureToChileanSpanishInTestMethod()
        {
            Assert.Equal("es-CL", Thread.CurrentThread.CurrentUICulture.Name);
        }

        [Theory]
        [InlineData("it-IT")]
        [InlineData("ja-JP")]
        [InlineData("nb-NO")]
        public void RefreshCachedCultureRelatedInformationWithinTest(string culture)
        {
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            var attr = new UseCultureAttribute(culture);

            attr.Before(null);

            var ri = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);

            Assert.Equal(attr.Culture, Thread.CurrentThread.CurrentCulture);
            Assert.Equal(ri.TwoLetterISORegionName, RegionInfo.CurrentRegion.TwoLetterISORegionName);

            attr.After(null);

            Assert.Equal(originalCulture, Thread.CurrentThread.CurrentCulture);
        }
    }
}
