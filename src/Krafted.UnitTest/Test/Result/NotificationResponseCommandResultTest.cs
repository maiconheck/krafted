using System.Collections.Generic;
using System.Linq;
using Krafted.Test.Result;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class NotificationResponseCommandResultTest
    {
        [Fact]
        public void NewNotificationResponseCommandResult_NewNotificationResponseCommandResultShouldBeCreated()
        {
            var commandResult = new NotificationResponseCommandResult
            {
                Codigo = 1,
                Dados = new List<Notification>
                {
                    new Notification("The property 1", "The message 1"),
                    new Notification("The property 2", "The message 2")
                },
                Mensagem = "The message"
            };

            var dados = commandResult.Dados.ToList();

            Assert.Equal("The message", commandResult.Mensagem);

            Assert.Equal("The property 1", dados.First().Property);
            Assert.Equal("The message 1", dados.First().Message);
            Assert.Equal("The property 2", dados.Second().Property);
            Assert.Equal("The message 2", dados.Second().Message);
        }
    }
}