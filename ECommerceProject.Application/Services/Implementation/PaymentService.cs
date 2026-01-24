using ECommerceProject.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Application.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeService _stripeService;

        private readonly IProductSurvice _productService;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        private readonly IWalletService _walletService;
        public PaymentService(IStripeService stripeService, IUnitOfWork unitOfWork, IOrderService orderService, ICartService cartService, IWalletService walletService, IProductSurvice productService)
        {
            _stripeService = stripeService;
            _unitOfWork = unitOfWork;

            _productService = productService;
            _orderService = orderService;
            _cartService = cartService;

            _walletService = walletService;
        }

        public async Task HandleSuccessfulPaymentAsync(int orderId)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var order = await _unitOfWork.Orders.GetAsync(o => o.Id == orderId,
                                                    q => q.Include(o => o.OrderItems));

                // is order found
                if (order == null)
                    throw new Exception("Order not found");


                var cartItemIds = order.OrderItems.Select(oi => oi.CartItemId).ToList();



                // Change payment status to Paid
                await _orderService.MarkAsPaidAsync(orderId);

                // Remove items from cart
                await _cartService.RemoveItemsAsync(cartItemIds);

                // Reduce Quantity
                await _productService.ReduceQuantitiesAsync(order.OrderItems);

                // Send money to Seller wallet 
                await _walletService.SendMoneyToSellers(order.Id);


                // Commit
                await _unitOfWork.CommitAsync();

            }
            catch(Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task<string> PayAsync(int orderId, string userId)
        {
            try
            {
                // Get the order
                var order = await _unitOfWork.Orders.GetAsync(
                            o => o.Id == orderId,
                   q => q.Include(o => o.OrderItems)
                                .ThenInclude(oi => oi.Product)
                );

                // is order found
                if (order == null)
                    throw new Exception("Order not found");

                // is order for this user
                if(order.UserId != userId)
                    throw new UnauthorizedAccessException();

                // is order not payed
                if (order.PaymentStatus == PaymentStatus.Paid)
                    throw new InvalidOperationException("Order already Payed");


                return await _stripeService.CreatePaymentSessionAsync(order);

            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
