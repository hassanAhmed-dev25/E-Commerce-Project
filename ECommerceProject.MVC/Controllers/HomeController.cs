using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductSurvice _productSurvice;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductSurvice productSurvice, ICategoryService categoryService)
        {
            _logger = logger;
            _productSurvice = productSurvice;
            _categoryService = categoryService;
        }


        // Show all products
        public async Task<IActionResult> Index(int? catgId)
        {

            var allProducts = catgId == null
                ? await _productSurvice.GetAllProductsAsync()
                : await _productSurvice.GetProductsByCategoryIdAsync((catgId.Value));


            var catgRes = await _categoryService.GetAllCategoriesAsync();

            ViewBag.Categories = catgRes.result;

            return View(allProducts.result);
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
