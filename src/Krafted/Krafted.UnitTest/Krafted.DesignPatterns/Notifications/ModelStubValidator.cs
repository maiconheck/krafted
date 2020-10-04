using FluentValidation;

namespace Krafted.UnitTest.Krafted.DesignPatterns.Notifications
{
    public class ModelStubValidator : AbstractValidator<ModelStub>
    {
        public ModelStubValidator()
        {
            RuleFor(p => p.Age)
                .GreaterThan(18)
                .WithMessage("The age should be greater than 18.");

            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("The name is required.")
                .MinimumLength(3)
                    .WithMessage("The name must be at least 3 characters.");
        }
    }
}
