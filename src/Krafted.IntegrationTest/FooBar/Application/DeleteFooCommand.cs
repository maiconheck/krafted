using System;
using SharedKernel.Application.Commands;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class DeleteFooCommand : ICommand
    {
        public DeleteFooCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}