using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Application.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeService _stripeService;

        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        public PaymentService(IStripeService stripeService, IUnitOfWork unitOfWork, IOrderService orderService, ICartService cartService)
        {
            _stripeService = stripeService;
            _unitOfWork = unitOfWork;

            _orderService = orderService;
            _cartService = cartService;
        }

        public async Task HandleSuccessfulPaymentAsync(int orderId)
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
