using System;

namespace SharedKernel.Application.Commands
{
    public class DeleteByIdCommand : ICommand
    {
        public DeleteByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}