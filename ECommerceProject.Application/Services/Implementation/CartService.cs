using ECommerceProject.Application.DTOs.Cart;

namespace ECommerceProject.Application.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<CartDto> GetOrCreateCartAsync(string userId)
        {
            
            var res = await _unitOfWork.Carts.GetAsync(c => c.UserId == userId);


            // return it if its already exists
            if (res != null)
            {
                return new CartDto 
                {
                    Id = res.Id,
                    UserId = userId,
                    CreatedAt = res.CreatedAt 
                };
            }

            var newCart = new Cart
            {
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };


            // Create it
            await _unitOfWork.Carts.AddAsync(newCart);

            // Save it
            await _unitOfWork.SaveChangesAsync();


            // return it
            return new CartDto 
            {
                Id = newCart.Id,
                UserId = userId,
                CreatedAt = newCart.CreatedAt 
            };


        }

        public async Task RemoveItemsAsync(IEnumerable<int> cartItemIds)
        {
            var items = await _unitOfWork.CartItems
                                        .GetAllAsync(ci => cartItemIds.Contains(ci.Id));


            _unitOfWork.CartItems.RemoveRangeAsync(items);

            await _unitOfWork.SaveChangesAsync();

        }

    }
}
