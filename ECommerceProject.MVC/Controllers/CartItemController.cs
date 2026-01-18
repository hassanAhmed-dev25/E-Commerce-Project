using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceProject.MVC.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }


        public async Task<IActionResult> AddToCart(CreateCartItemDto cartItemDto)
        {

            // UserId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            // Get or Create Cart
            var cart = await _cartService.GetOrCreateCartAsync(userId);

            //var createCartItem =  productDetailsVM.CartItem;

            // Add CartId
            cartItemDto.CartId = cart.Id;

            // Add to Cart
            var cartItemResult = await _cartItemService.AddToCartItemAsync(cartItemDto);


            return RedirectToAction("ShowAllProducts", "Product");

        }


        
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            // UserId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            // Get or Create Cart
            var cart = await _cartService.GetOrCreateCartAsync(userId);

            var response = await _cartItemService.DeleteFromCartItemAsync(cartItemId);

            if(!response.isSuccess)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Cart");

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
