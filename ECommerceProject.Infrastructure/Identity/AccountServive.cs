using ECommerceProject.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Infrastructure.Identity
{
    public class AccountServive : IAccountServive
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountServive(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        
        public async Task<IdentityResult> RegisterUserAsync(RegisterUser user)
        {
            try
            {
                var userRes = new ApplicationUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                };

                var result = await _userManager.CreateAsync(userRes, user.Password);

                return result;
            }
            catch
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<bool> IsUserNameUniqueAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) == null;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }
    }
}
