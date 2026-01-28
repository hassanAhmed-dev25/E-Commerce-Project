using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceProject.MVC.Controllers
{

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public readonly ICartItemService _cartItemService;
        public CartController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }



        public async Task<IActionResult> Index()
        {
            // Get the user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();


            // Get its cart
            var cart = await _cartService.GetOrCreateCartAsync(userId);


            // Get its item
            var cartItems = (await _cartItemService.GetMyCartItemsAsync(cart.Id)).result;

            
            var vm = cartItems.Select(ci => new CartItemVM
            {
                Items = ci,
                MaxQuantity = ci.maxQuantity,
            }).ToList();


            return View(vm);

        }
    }
}
