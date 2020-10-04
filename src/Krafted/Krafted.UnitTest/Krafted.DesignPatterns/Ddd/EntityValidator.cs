using FluentValidation;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Ddd
{
    public class EntityValidator : AbstractValidator<EntityStub>
    {
        public EntityValidator()
        {
            RuleFor(p => p.Age)
                .NotEmpty()
                .WithMessage("Enter the age.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Enter the name.");
        }
    }
}
