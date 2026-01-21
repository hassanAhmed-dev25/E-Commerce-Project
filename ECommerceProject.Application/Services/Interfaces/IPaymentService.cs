namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Response<bool>> StartPaymentAsync(decimal amount);
    }
}
