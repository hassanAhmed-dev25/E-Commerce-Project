using ECommerceProject.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IAccountServive
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUser user);
        //Task<bool> LoginUserAsync(LoginUser user);
    }
}
