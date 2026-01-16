using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Product;
using ECommerceProject.Application.Services.Implementation;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.Models;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductSurvice _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductSurvice productService, ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
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

            var vm = allProducts.Select(p => new ProductDetailsVM
            {
                Product = p,

            }).ToList();


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
