using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

namespace ECommerceProject.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        public PaymentController(IPaymentService paymentService, IOrderService orderService, ICartService cartService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _cartService = cartService;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Pay(int orderId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();


            var url = await _paymentService.PayAsync(orderId, userId);
           
            Response.Headers.Add("Location", url);

            return StatusCode(303);
        }

        public async Task<IActionResult> ConfirmPayment(string sessionId)
        {

            if (string.IsNullOrEmpty(sessionId))
                return BadRequest();

            var service = new SessionService();
            var session = await service.GetAsync(sessionId);

            if (session.PaymentStatus != "paid")
                return RedirectToAction("Cancel");

            var orderId = int.Parse(session.Metadata["orderId"]);

            await _paymentService.HandleSuccessfulPaymentAsync(orderId);

            return RedirectToAction("Success");

        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

    }
}

  