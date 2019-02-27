using System;
using SharedKernel.Application.Commands;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class CancelFooCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}