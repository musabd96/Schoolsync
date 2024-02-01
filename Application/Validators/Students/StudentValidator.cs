using Application.Dtos;
using FluentValidation;

namespace Application.Validators.Students
{
    public class StudentValidator : AbstractValidator<StudentDto>
    {
        public StudentValidator()
        {
            RuleFor(student => student.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(student => student.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(student => student.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(BeValidDateOfBirthFormat).WithMessage("Date of birth should be in the format (yyyy, MM, dd).");

            RuleFor(student => student.Address)
                .NotEmpty().WithMessage("Adress cannot be empty.");

            RuleFor(student => student.PhoneNumber)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^\+?[0-9]*$").WithMessage("Invalid phone number format. Only digits are allowed.");

            RuleFor(student => student.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address format.");
        }

        private bool BeValidDateOfBirthFormat(DateOnly dateOfBirth)
        {
            try
            {
                DateTime dateTime = new(dateOfBirth.Year, dateOfBirth.Month, dateOfBirth.Day);
                return true;
            }
            catch { return false; }
        }
    }
}
