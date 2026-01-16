using ECommerceProject.Application.DTOs.Cart;
using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Product;
using ECommerceProject.Application.Services.Implementation;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.Domain.Entities;
using ECommerceProject.MVC.Models;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductSurvice _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductSurvice productService, ICategoryService categoryService, ICartItemService cartItemService, ICartService cartService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _cartItemService = cartItemService;
            _cartService = cartService;
        }


        // Show all products
        [HttpGet]
        public async Task<IActionResult> Index(int? catgId)
        {
            var products = catgId == null
                ? await _productService.GetAllProductsAsync()
                : await _productService.GetProductsByCategoryIdAsync(catgId.Value);

            ViewBag.Categories = (await _categoryService.GetAllCategoriesAsync()).result;
            ViewBag.SelectedCategory = catgId;

            var allProducts = products.result;


            // get its cart
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CartDto cart = null;
            if (!string.IsNullOrEmpty(userId))
                cart = await _cartService.GetOrCreateCartAsync(userId);


            var vm = new List<ProductDetailsVM>();
            foreach(var product in products.result)
            {
                vm.Add(new ProductDetailsVM
                {
                    Product = product,
                    IsInCart = cart != null && await _cartItemService.IsProductInCartAsync(cart.Id, product.Id),
                });
            }

            return View(vm);
        }


        // View Product
        [HttpGet]
        public async Task<IActionResult> ViewProduct(int prodId)
        {
            var productResult = await _productService.GetProductByIdAsync(prodId); 

            var prod = productResult.result;

            return View(prod);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
        //public async Task<IActionResult> 


    }
}
