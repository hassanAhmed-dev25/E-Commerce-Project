namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IEmailConfirmationService
    {
        Task SendConfirmationEmailAsync(string userId, string email, string baseUrl);
        Task SendResetPasswordEmailAsync(string userId, string email, string baseUrl);

    }
}
