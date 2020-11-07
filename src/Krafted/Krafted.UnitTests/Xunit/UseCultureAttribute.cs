// A attribute to replace the CurrentCulture with another culture.
//
// This class was obtained from the Xunit samples.
// Source: https://raw.githubusercontent.com/xunit/samples.xunit/main/UseCulture/UseCultureAttribute.cs
// Retrieved in November 2020.

using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Xunit.Sdk;

namespace Krafted.UnitTest.Xunit
{
    /// <summary>
    /// Apply this attribute to your test method to replace the
    /// <see cref="Thread.CurrentThread" /> <see cref="CultureInfo.CurrentCulture" /> and
    /// <see cref="CultureInfo.CurrentUICulture" /> with another culture.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class UseCultureAttribute : BeforeAfterTestAttribute
    {
        private readonly Lazy<CultureInfo> _culture;
        private readonly Lazy<CultureInfo> _uiCulture;

        private CultureInfo _originalCulture;
        private CultureInfo _originalUICulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="UseCultureAttribute"/> class.
        /// Replaces the culture and UI culture of the current thread with
        /// <paramref name="culture" />.
        /// </summary>
        /// <param name="culture">The name of the culture.</param>
        /// <remarks>
        /// <para>
        /// This constructor overload uses <paramref name="culture" /> for both
        /// <see cref="Culture" /> and <see cref="UICulture" />.
        /// </para>
        /// </remarks>
        public UseCultureAttribute(string culture)
            : this(culture, culture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UseCultureAttribute"/> class.
        /// Replaces the culture and UI culture of the current thread with
        /// <paramref name="culture" /> and <paramref name="uiCulture" />.
        /// </summary>
        /// <param name="culture">The name of the culture.</param>
        /// <param name="uiCulture">The name of the UI culture.</param>
        public UseCultureAttribute(string culture, string uiCulture)
        {
            this._culture = new Lazy<CultureInfo>(() => new CultureInfo(culture, false));
            this._uiCulture = new Lazy<CultureInfo>(() => new CultureInfo(uiCulture, false));
        }

        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public CultureInfo Culture => _culture.Value;

        /// <summary>
        /// Gets the UI culture.
        /// </summary>
        /// <value>
        /// The UI culture.
        /// </value>
        public CultureInfo UICulture => _uiCulture.Value;

        /// <summary>
        /// Stores the current <see cref="Thread.CurrentPrincipal" />
        /// <see cref="CultureInfo.CurrentCulture" /> and <see cref="CultureInfo.CurrentUICulture" />
        /// and replaces them with the new cultures defined in the constructor.
        /// </summary>
        /// <param name="methodUnderTest">The method under test.</param>
        public override void Before(MethodInfo methodUnderTest)
        {
            _originalCulture = Thread.CurrentThread.CurrentCulture;
            _originalUICulture = Thread.CurrentThread.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = Culture;
            Thread.CurrentThread.CurrentUICulture = UICulture;

            CultureInfo.CurrentCulture.ClearCachedData();
            CultureInfo.CurrentUICulture.ClearCachedData();
        }

        /// <summary>
        /// Restores the original <see cref="CultureInfo.CurrentCulture" /> and
        /// <see cref="CultureInfo.CurrentUICulture" /> to <see cref="Thread.CurrentPrincipal" />.
        /// </summary>
        /// <param name="methodUnderTest">The method under test.</param>
        public override void After(MethodInfo methodUnderTest)
        {
            Thread.CurrentThread.CurrentCulture = _originalCulture;
            Thread.CurrentThread.CurrentUICulture = _originalUICulture;

            CultureInfo.CurrentCulture.ClearCachedData();
            CultureInfo.CurrentUICulture.ClearCachedData();
        }
    }
}
