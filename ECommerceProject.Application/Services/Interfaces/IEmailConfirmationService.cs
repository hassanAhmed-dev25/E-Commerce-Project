namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IEmailConfirmationService
    {
        Task SendConfirmationEmailAsync(string userId, string email, string baseUrl);

    }
}
