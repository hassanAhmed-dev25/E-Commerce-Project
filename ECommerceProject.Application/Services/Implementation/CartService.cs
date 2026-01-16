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


        public Task<CartDto> GetOrCreateCart(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
