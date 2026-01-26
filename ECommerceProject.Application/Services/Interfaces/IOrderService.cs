namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<decimal> GetTotalPriceById(int id);
        Task<Response<IEnumerable<GetOrderDto>>> GetMyOrdersAsync(string userId);

        Task<int> PlaceOrderAsync(PlaceOrderDto order);
        Task<GetOrderDto> GetOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);

        Task<int> GetTotalOrdersAsync(string? userId = null);

        Task MarkAsPaidAsync(int orderId);
      

    }
}
