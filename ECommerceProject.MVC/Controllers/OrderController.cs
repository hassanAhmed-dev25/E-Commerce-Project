using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;
        public OrderController(IOrderService orderService, ICartItemService cartItemService)
        {
            _orderService = orderService;
            _cartItemService = cartItemService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Checkout(List<int> selectedCartItemIds)
        {
            var cartItemsDto = (await _cartItemService.GetCartItemsByIdAsync(selectedCartItemIds)).result;


            var vm = new CheckoutVM
            {
                CartItems = cartItemsDto, 
                TotalAmount = cartItemsDto.Sum(ci => ci.Quantity * ci.UnitPrice)
            };

            return View(vm);
        }

    }
}
