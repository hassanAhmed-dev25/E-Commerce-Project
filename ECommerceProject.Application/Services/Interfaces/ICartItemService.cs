using ECommerceProject.Application.DTOs.CartItem;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<Response<bool>> AddToCartItemAsync(CreateCartItemDto item);
        Task<Response<bool>> DeleteFromCartItemAsync(int cartItemId);
    }
}
