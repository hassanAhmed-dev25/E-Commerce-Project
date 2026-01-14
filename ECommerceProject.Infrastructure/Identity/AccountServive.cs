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
                // Is Email exists
                if (await _userManager.FindByEmailAsync(user.Email) != null)
                {
                    return IdentityResult.Failed(
                        new IdentityError { Code = "Email", Description = "Email already exists" });
                }

                // Is User Name exists
                if (await _userManager.FindByNameAsync(user.UserName) != null)
                {
                    return IdentityResult.Failed(
                        new IdentityError { Code = "userName", Description = "User name already exists" });
                }



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
