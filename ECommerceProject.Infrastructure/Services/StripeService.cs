using ECommerceProject.Application.DTOs.Order;
using Microsoft.AspNetCore.Http;
using Stripe.Checkout;

namespace ECommerceProject.Infrastructure.Services
{
    public class StripeService : IStripeService
    {
        private readonly string _baseUrl;

        public StripeService(IHttpContextAccessor http)
        {
            var req = http.HttpContext.Request;
            _baseUrl = $"{req.Scheme}://{req.Host}";
        }



        public async Task<string> CreatePaymentSessionAsync(Order order)
        {
            
            var options = new SessionCreateOptions
            {
                Mode = "payment",

                LineItems = order.OrderItems.Select(item => new SessionLineItemOptions
                {
                    Quantity = item.Quantity,
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "egp",
                        UnitAmount = (long)(item.UnitPrice * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name,
                        }
                    }
                }).ToList(),

                Metadata = new Dictionary<string, string>
                {
                    { "orderId", order.Id.ToString() }
                },

                SuccessUrl = $"{_baseUrl}/Payment/ConfirmPayment?sessionId={{CHECKOUT_SESSION_ID}}",
                CancelUrl = $"{_baseUrl}/Payment/Cancel"
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return session.Url;

        }


    }
}
