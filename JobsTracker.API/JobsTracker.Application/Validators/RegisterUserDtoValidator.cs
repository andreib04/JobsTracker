using JobsTracker.Application.DTOs.AuthDTOs;
using FluentValidation;

namespace JobsTracker.Application.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .ChildRules(password =>
                {
                    password.RuleFor(p => p)
                        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                        .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
                });
        }
    }
}
