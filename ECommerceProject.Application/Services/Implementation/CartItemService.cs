using ECommerceProject.Application.DTOs.CartItem;

namespace ECommerceProject.Application.Services.Implementation
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Response<bool>> AddToCartItemAsync(CreateCartItemDto item)
        {
            

            // Mapping
            var cartItem = new CartItem
            {
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                CartId = item.CartId,
                ProductId = item.ProductId,
            };

            // Adding
            await _unitOfWork.CartItems.AddAsync(cartItem);


            // Saving
            await _unitOfWork.SaveChangesAsync();

            return new Response<bool>(true, null, true);

        }

        public async Task<Response<bool>> DeleteFromCartItemAsync(int cartItemId)
        {
            // Remove
            await _unitOfWork.CartItems.RemoveAsync(cartItemId);

            // Saving
            await _unitOfWork.SaveChangesAsync();

            // Return
            return new Response<bool>(true, null, true);
        }


        public async Task<bool> IsProductInCartAsync(int cartId, int productId)
        {
            return await _unitOfWork.CartItems.AnyAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
        }



    }
}
