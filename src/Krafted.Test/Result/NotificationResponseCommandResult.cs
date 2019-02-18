using System.Collections.Generic;

namespace Krafted.Test.Result
{
    public class NotificationResponseCommandResult
    {
        public IEnumerable<Notification> Dados { get; set; }

        public int Codigo { get; set; }

        public string Mensagem { get; set; }
    }

    public class Notification
    {
        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; set; }

        public string Message { get; set; }
    }
}