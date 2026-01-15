using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace ECommerceProject.Infrastructure.Services
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly IEmailService _emailService;
        public EmailConfirmationService(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }


        public async Task SendConfirmationEmailAsync(string userId, string email, string baseUrl)
        {
            // Find the user
            var user = await _userManager.FindByIdAsync(userId);

            // Genereate token for email verify
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


            // encode Token
            var encodedToken = WebUtility.UrlEncode(token);
            // Create link for email verify
            var link = $"{baseUrl}/Account/ConfirmEmail?UserId={userId}&Token={encodedToken}";


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
        }

        public async Task SendResetPasswordEmailAsync(string userId, string email, string baseUrl)
        {

            // Find the user
            var user = await _userManager.FindByIdAsync(userId);

            // Genereate token for reset password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            // encode Token
            var encodedToken = WebUtility.UrlEncode(token);
            // Create link for email verify
            var link =
                            $"{baseUrl}/Account/ResetPassword" +
                            $"?email={Uri.EscapeDataString(user.Email)}" +
                            $"&token={encodedToken}";


            // the message
            var message = $@"
                    <h2>Reset Password</h2>
                    <p>Please confirm your account by clicking the link below to reset your password:</p>
                    <a href='{link}'>Confirm Email</a>
                ";

            // Send Email
            await _emailService.SendAsync(
                user.Email,
                "Reset Password",
                message
            );
        }
    }
}
