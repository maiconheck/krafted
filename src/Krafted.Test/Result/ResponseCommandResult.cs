using System;
using Newtonsoft.Json;

namespace Krafted.Test.Result
{
    public class ResponseCommandResult
    {
        public ResponseCommandResult(string id, bool success, string mensagem)
        {
            Id = new Guid(id);
            Success = success;
            Message = mensagem;
        }

        public ResponseCommandResult(bool success, string mensagem)
        {
            Success = success;
            Message = mensagem;
        }

        public Guid? Id { get; set; }

        [JsonProperty("mensagem")]
        public string Message { get; set; }

        public bool Success { get; set; }
    }
}