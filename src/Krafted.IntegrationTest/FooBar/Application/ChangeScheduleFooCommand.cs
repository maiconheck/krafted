using System;
using SharedKernel.Application.Commands;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class ChangeScheduleFooCommand : ICommand
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}