using ECommerceProject.Application.DTOs.Cart;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetOrCreateCartAsync(string userId);
        Task RemoveItemsAsync(IEnumerable<int> cartItemIds);
    }

}
