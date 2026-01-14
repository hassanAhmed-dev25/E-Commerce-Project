using ECommerceProject.Application.DTOs.Account;
using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace ECommerceProject.Infrastructure.Identity
{
    public class AccountServive : IAccountServive
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public AccountServive(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        
        public async Task<IdentityResult> RegisterUserAsync(RegisterUser user, string baseUrl)
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
                if (!result.Succeeded)
                    return result;


                // Genereate token for email verify
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userRes);

                
                // encode Token
                var encodedToken = WebUtility.UrlEncode(token);
                // Create link for email verify
                var link = $"{baseUrl}/Account/ConfirmEmail?UserId={userRes.Id}&Token={encodedToken}";


                // the message
                var message = $@"
                    <h2>Confirm your email</h2>
                    <p>Please confirm your account by clicking the link below:</p>
                    <a href='{link}'>Confirm Email</a>
                ";

                // Send Email
                await _emailService.SendAsync(
                    user.Email,
                    "Confirm your email",
                    message
                );




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

        public async Task<IdentityResult> VerifyEmailAsync(VerifyEmailDto verifyEmail)
        {
            if (string.IsNullOrEmpty(verifyEmail.UserId) || string.IsNullOrEmpty(verifyEmail.Token))
                return IdentityResult.Failed();

            var user = await _userManager.FindByIdAsync(verifyEmail.UserId);
            if (user == null)
                return IdentityResult.Failed();

            return await _userManager.ConfirmEmailAsync(user, verifyEmail.Token);
        }


    }
}
