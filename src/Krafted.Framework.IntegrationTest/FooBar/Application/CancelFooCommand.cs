using Krafted.Framework.SharedKernel.Application.Commands;
using System;

namespace Krafted.Framework.IntegrationTest.FooBar.Application
{
    public class CancelFooCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}