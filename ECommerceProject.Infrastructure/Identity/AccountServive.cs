using ECommerceProject.Application.Common;
using ECommerceProject.Application.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Net;

namespace ECommerceProject.Infrastructure.Identity
{
    public class AccountServive : IAccountServive
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailConfirmationService _emailConfirmationService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountServive(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailConfirmationService emailConfirmationService)
        {
            _userManager = userManager;
            _emailConfirmationService = emailConfirmationService;
            _signInManager = signInManager;
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




                // Add role
                string[] allowedRoles = { "Seller", "Buyer" };

                if (!allowedRoles.Contains(user.SelectedRole))
                {
                    return IdentityResult.Failed(
                        new IdentityError { Description = "Invalid role" }
                    );
                }
                var resultRole = await _userManager.AddToRoleAsync(userRes, user.SelectedRole);


                // Send Email
                await _emailConfirmationService.SendConfirmationEmailAsync(userRes.Id, userRes.Email, baseUrl);


                return result;


            }
            catch
            {
                return IdentityResult.Failed();
            }
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


        public async Task<Response<bool>> LoginUserAsync(LogInUser user)
        {
            var userDetails = await _userManager.FindByEmailAsync(user.Email);

            if (userDetails == null)
            {
                return new Response<bool>(false, "Invalid email or password", false);
            }

            if (!userDetails.EmailConfirmed)
            {
                return new Response<bool>(false, "Please confirm your email first", false);
            }

            var result = await _signInManager.PasswordSignInAsync(
                userDetails.UserName,
                user.Password,
                user.RememberMe,
                false
            );

            if(!result.Succeeded)
            {
                return new Response<bool>(false, "Invalid email or password", false);
            }


            return new Response<bool>(true, null, true);
        }


        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }



        public async Task<bool> IsUserNameUniqueAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName) == null;
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) == null;
        }




        // send link to Reset password
        public async Task<IdentityResult> SendResetPasswordLinkAsync(ForgetPasswordDto user, string baseUrl)
        {
            var curUser = await _userManager.FindByEmailAsync(user.Email);

            if(curUser == null)
                return IdentityResult.Failed();

            await _emailConfirmationService.SendResetPasswordEmailAsync(curUser.Id,curUser.Email, baseUrl);

            return IdentityResult.Success;
        }
        // Reset password
        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto user)
        {
            var oldUser = await _userManager.FindByEmailAsync(user.Email);

            if (oldUser == null)
                return IdentityResult.Failed();

            var result = await _userManager.ResetPasswordAsync(
                oldUser,
                user.Token,
                user.NewPassword
            );

            if (!result.Succeeded)
                return IdentityResult.Failed();

            return IdentityResult.Success;
        }
    }
}
