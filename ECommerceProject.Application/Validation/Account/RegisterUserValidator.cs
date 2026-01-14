using ECommerceProject.Application.DTOs.Account;
using FluentValidation;

namespace ECommerceProject.Application.Validation.Account
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress();

            RuleFor(r => r.UserName)
                .NotEmpty().WithMessage("User name is required")
                .MinimumLength(4)
                .MaximumLength(100);

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6)
                .MaximumLength(50);

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .Equal(r => r.Password)
                .WithMessage("Passwords do not match");
        }
    }
}
