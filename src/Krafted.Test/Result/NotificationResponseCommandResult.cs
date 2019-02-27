using System.Collections.Generic;

namespace Krafted.Test.Result
{
    public class NotificationResponseCommandResult
    {
        public IEnumerable<Notification> Dados { get; set; }

        public int Codigo { get; set; }

        public string Mensagem { get; set; }
    }
}