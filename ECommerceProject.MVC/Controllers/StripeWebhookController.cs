using ECommerceProject.Application.Interfaces;
using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace ECommerceProject.MVC.Controllers
{
    [ApiController]
    [Route("stripe/webhook")]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IOrderService _orderService;

        public StripeWebhookController(IConfiguration config, IOrderService orderService)
        {
            _config = config;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _config["Stripe:Secret"]
            );

            if (stripeEvent.Type == "checkout.session.completed")
            {
                var session = stripeEvent.Data.Object as Session;
                var orderId = int.Parse(session!.Metadata["orderId"]);

                await _orderService.MarkAsPaidAsync(orderId);
            }

            return Ok();
        }
    }
}
