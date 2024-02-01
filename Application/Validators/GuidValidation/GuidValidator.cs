using FluentValidation;

namespace Application.Validators.GuidValidation
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(guid => guid)
            .NotEmpty().WithMessage("Person Id can not be empty")
            .NotNull().WithMessage("Person Id can not be null");
        }
    }
}
