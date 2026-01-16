using ECommerceProject.Application.DTOs.Cart;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetOrCreateCart(string userId);
    }

}
