using ECommerceProject.Application.DTOs.CartItem;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<Response<bool>> AddToCartItemAsync(CreateCartItemDto item);
        Task<Response<bool>> DeleteFromCartItemAsync(int cartItemId);
        Task<bool> IsProductInCartAsync(int cartId, int productId);
        Task<Response<IEnumerable<CartItemDto>>> GetMyCartItemsAsync(int cartId);
        Task<Response<IEnumerable<CartItemDto>>> GetCartItemsByIdAsync(IEnumerable<int> selectedCartItemIds);

        Task<int> Increase(int cartItemId);
        Task<int> Decrease(int cartItemId);
    }
}
