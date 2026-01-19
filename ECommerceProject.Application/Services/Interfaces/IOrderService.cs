using ECommerceProject.Application.DTOs.Order;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IOrderService
    {

        Task PlaceOrderAsync(PlaceOrderDto order);
        Task<GetOrderDto> GetOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);

    }
}
