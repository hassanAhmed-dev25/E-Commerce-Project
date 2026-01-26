using ECommerceProject.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IAccountServive
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUser user, string baseUrl);
        Task<IdentityResult> VerifyEmailAsync(VerifyEmailDto verifyEmail);
        Task<Response<bool>> LoginUserAsync(LogInUser user);
        Task LogOutAsync();
        Task<IdentityResult> SendResetPasswordLinkAsync(ForgetPasswordDto user, string baseUrl);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto user);


        //Task<bool> CreateRole(IdentityResult userResult);


        Task<bool> IsUserNameUniqueAsync(string userName);
        Task<bool> IsEmailUniqueAsync(string email);



        Task<int> GetTotalUsers();


        
    }
}
