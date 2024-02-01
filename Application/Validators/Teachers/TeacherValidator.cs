using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Teachers
{
    public class TeacherValidator : AbstractValidator<TeacherDto>
    {
        public TeacherValidator()
        {
            RuleFor(teacher => teacher.FirstName)
                .NotEmpty().WithMessage("Teacher firstname cannot be empty")
                .NotNull().WithMessage("Teacher firstname cannot be null");

            RuleFor(teacher => teacher.LastName)
                .NotEmpty().WithMessage("Teacher lastname cannot be empty")
                .NotNull().WithMessage("Teacher lastname cannot be null")
                .MaximumLength(50).WithMessage("Teacher lastname must not exceed 50 characters");

            RuleFor(teacher => teacher.DateOfBirth)
                .NotNull().WithMessage("Date of birth cannot be null")
                .Must(BeAValidDate).WithMessage("Invalid date of birth format");

            RuleFor(teacher => teacher.Address)
                .NotEmpty().WithMessage("Teacher address cannot be empty")
                .NotNull().WithMessage("Teacher address cannot be null");

            RuleFor(teacher => teacher.PhoneNumber)
                .NotEmpty().WithMessage("Teacher phone number cannot be empty")
                .NotNull().WithMessage("Teacher phone number cannot be null")
                .Matches(@"^[0-9]+$").WithMessage("Phone number should contain only digits");

            RuleFor(teacher => teacher.Email)
                .NotEmpty().WithMessage("Teacher email cannot be empty")
                .NotNull().WithMessage("Teacher email cannot be null")
                .EmailAddress().WithMessage("Invalid email address format");
        }

        private bool BeAValidDate(DateOnly date)
        {
            // Add custom logic to validate date format or any other specific rules
            // Date should not be in the future
            return date <= DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
