namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IStripeService
    {
        Task<string> CreatePaymentSessionAsync(Order order);
    }
}
