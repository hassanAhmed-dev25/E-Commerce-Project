using ECommerceProject.Application.DTOs.Account;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceProject.Infrastructure.Services
{
    internal class ExternalAuthService : IExternalAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ExternalAuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private async Task<string> GenerateUniqueUsernameAsync( string? firstName, string? lastName)
        {
            var baseUsername =
                $"{firstName}.{lastName}".ToLower().Replace(" ", "");

            while (true)
            {
                var username = $"{baseUsername}{Random.Shared.Next(1000, 9999)}";
                var exists = await _userManager.FindByNameAsync(username);

                if (exists == null)
                    return username;
            }
        }



        public async Task<ExternalLoginResultDto> ExternalLoginAsync(ExternalLoginDto dto)
        {
            bool isNewUser = false;
            bool isHaveRole = false;

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                isNewUser = true;

                user = new ApplicationUser
                {
                    UserName = await GenerateUniqueUsernameAsync(dto.FirstName, dto.LastName),
                    Email = dto.Email,
                    EmailConfirmed = true,

                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddLoginAsync(
                    user,
                    new UserLoginInfo(
                        dto.Provider,
                        dto.ProviderKey,
                        dto.Provider)
                    );
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.IsNullOrEmpty())
                isHaveRole = true;

            await _signInManager.SignInAsync(user, false);


            return new ExternalLoginResultDto
            {
                IsSuccess = true,
                IsNewUser = isNewUser,
                IsHaveRole = isHaveRole,

                Message = "Logged in successfully"
            };

        }

    }
}
