using Krafted.Localization.Abstractions;

namespace Krafted.UnitTest.Krafted.Rfc.ProblemDetails
{
    public class LocalizerServiceStub : ILocalizerService
    {
        public string GetValue(string name) => $"{name} message.";
    }
}
