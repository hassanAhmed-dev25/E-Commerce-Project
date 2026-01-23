using ECommerceProject.Application.DTOs.CartItem;
using Microsoft.EntityFrameworkCore;

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


        public async Task<Response<IEnumerable<CartItemDto>>> GetMyCartItemsAsync(int cartId)
        {

            var cartItems = await _unitOfWork.CartItems.GetAllAsync(ci => ci.CartId == cartId, 
                                                                            q => q.Include(ci => ci.Product));



            var res = cartItems.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                ProductName = ci.Product.Name,
                ImageUrl = ci.Product.ImageUrl,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice,
                maxQuantity = ci.Product.StockQuantity,

            }).ToList();



            return new Response<IEnumerable<CartItemDto>>(res, null, true);

        }

        public async Task<Response<IEnumerable<CartItemDto>>> GetCartItemsByIdAsync(IEnumerable<int> selectedCartItemIds)
        {

            var cartItems = await _unitOfWork.CartItems.GetAllAsync(ci => selectedCartItemIds.Contains(ci.Id),
                                                                            q => q.Include(ci => ci.Product));


            var res = cartItems.Select(ci => new CartItemDto
            {
                Id = ci.Id,
                ProductName = ci.Product.Name,
                ImageUrl = ci.Product.ImageUrl,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice,
                maxQuantity = ci.Product.StockQuantity,

            }).ToList();



            return new Response<IEnumerable<CartItemDto>>(res, null, true);
        }


        public async Task<int> Increase(int cartItemId)
        {
            int res;

            var entity = await _unitOfWork.CartItems.GetAsync(ci => ci.Id == cartItemId,
                                                                   q => q.Include(ci => ci.Product));
            if(entity == null)
                return 0;


            var stock = entity.Product.StockQuantity;

            // Increase
            if (entity.Quantity < stock)
            {
                entity.Quantity++;

                await _unitOfWork.CartItems.UpdateAsync(entity);

                await _unitOfWork.SaveChangesAsync();

                // Get new quantity
                res = entity.Quantity;
            }
            else
            {
                // Get last quantity
                res = entity.Quantity;
            }


            return res;


        }

        public async Task<int> Decrease(int cartItemId)
        {
            int res;

            var entity = await _unitOfWork.CartItems.GetAsync(ci => ci.Id == cartItemId,
                                                                   q => q.Include(ci => ci.Product));
            if (entity == null)
                return 0;


            // Decrease
            if (entity.Quantity > 1)
            {
                entity.Quantity--;

                await _unitOfWork.CartItems.UpdateAsync(entity);

                await _unitOfWork.SaveChangesAsync();
                // Get new quantity
                res = entity.Quantity;
            }
            else
            {
                // Get last quantity
                res = entity.Quantity;
            }

            return res;
        }

        
    }
}
