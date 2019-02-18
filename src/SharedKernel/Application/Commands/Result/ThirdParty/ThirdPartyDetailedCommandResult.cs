using Newtonsoft.Json;

namespace SharedKernel.Application.Commands.Result.ThirdParty
{
    public sealed class ThirdPartyDetailedCommandResult : ThirdPartyCommandResult
    {
        public ThirdPartyDetailedCommandResult(bool success, string message, object data) : base(success, message)
        {
            Data = data;
        }

        [JsonProperty("dados")]
        public object Data { get; }
    }
}
