using ECommerceProject.Application.DTOs.Account;
using FluentValidation;

namespace ECommerceProject.Application.Validation.Account
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        private readonly IAccountServive _accountServive;

        public RegisterUserValidator(IAccountServive accountServive)
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
                .MaximumLength(100)
                .MustAsync(async (userName, _) =>
                    await _accountServive.IsUserNameUniqueAsync(userName)

                ).WithMessage("User name already exists");


            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6)
                .MaximumLength(50);


            RuleFor(r => r.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required")
                .MinimumLength(6)
                .MaximumLength(50)
                .Equal(r => r.Password)
                .WithMessage("Passwords do not match");


        }
    }
}
