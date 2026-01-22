namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> PayAsync(int orderId, string userId);
        Task HandleSuccessfulPaymentAsync(int orderId);
    }
}
