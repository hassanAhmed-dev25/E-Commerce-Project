namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IStripeService
    {
        Task<string> CreatePaymentIntentAsync(decimal amount);
    }
}
