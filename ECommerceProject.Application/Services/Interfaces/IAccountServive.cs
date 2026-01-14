using ECommerceProject.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IAccountServive
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUser user, string baseUrl);
        //Task<bool> LoginUserAsync(LoginUser user);

        Task<bool> IsUserNameUniqueAsync(string userName);
        Task<bool> IsEmailUniqueAsync(string email);

        Task<IdentityResult> VerifyEmailAsync(VerifyEmailDto verifyEmail);
    }
}
