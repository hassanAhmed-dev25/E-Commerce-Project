using ECommerceProject.Application.DTOs.Order;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<decimal> GetTotalPriceById(int id);

        Task<int> PlaceOrderAsync(PlaceOrderDto order);
        Task<GetOrderDto> GetOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);


        Task MarkAsPaidAsync(int orderId);
      

    }
}
