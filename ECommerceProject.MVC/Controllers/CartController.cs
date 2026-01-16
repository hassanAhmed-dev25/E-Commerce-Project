using ECommerceProject.Application.DTOs.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {

            var cartItemDto = new CartItemDto{ ProductName="s", Quantity=10, UnitPrice=20 };
            var cartItemDto2 = new CartItemDto{ ProductName="s", Quantity=2, UnitPrice=2000 };
            var cartItemDto3 = new CartItemDto{ ProductName="s", Quantity=34, UnitPrice=3424324 };

            var cartItems = new List<CartItemDto>();

            cartItems.Add(cartItemDto);
            cartItems.Add(cartItemDto2);
            cartItems.Add(cartItemDto3);

            return View(cartItems);
        }
    }
}
