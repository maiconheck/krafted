using System;
using SharedKernel.Application.Commands;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class CreateFooCommand : ICommand
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}