using ECommerceProject.Application.DTOs.Product;
using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private readonly IProductSurvice _productSurvice;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductSurvice productSurvice, ICategoryService categoryService)
        {
            _productSurvice = productSurvice;
            _categoryService = categoryService;
        }



        public async Task<bool> LoadCategories()
        {
            // Get All categories
            var reponseCategories = await _categoryService.GetAllCategoriesAsync();

            // Check if the operation was successful
            if (!reponseCategories.isSuccess)
            {
                return false;
            }


            // Load categories to viewbag

            ViewBag.CategoryList = reponseCategories.result.Select(c =>
            new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();

            return true;
        }



        // Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Loading Categories List
            var isLoaded = await LoadCategories();

            if(!isLoaded)
            {
                return View("Error");
            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            // Validate the model
            // if false return the view with the model to show validation errors
            if (!ModelState.IsValid)
            {
                await LoadCategories();

                return View(productDto);
            }

            var res = await _productSurvice.CreateProductyAsync(productDto);

            if (!res.isSuccess)
            {
                TempData["error"] = "Product is not Created";

                return View("Error");
            }

            TempData["success"] = "Product Created successfully";

            return RedirectToAction("Index");
        }




        // Update
        [HttpGet]
        public async Task<IActionResult> Update(int prodId)
        {
            // Get category by id
            var ResponceProductDto = await _productSurvice.GetProductByIdAsync(prodId);

            // Check if the operation was successful
            if (!ResponceProductDto.isSuccess)
            {
                return View("Error");
            }


            // Extract the product data
            var product = ResponceProductDto.result;

            //// Mapp GetDTO to UpdateDTO
            var updateproductDto = new UpdateProductDto
            {
                Id = prodId,
                Name = product.Name,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive,
                Description = product.Description,
                CategoryId = product.CategoryId,
            };



            // Loading Categories List
            var isLoaded = await LoadCategories();

            if (!isLoaded)
            {
                return View("Error");
            }


            return View(updateproductDto);


        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            // Validate the model
            // if false return the view with the model to show validation errors
            if (!ModelState.IsValid)
            {
                await LoadCategories();

                return View(productDto);
            }

            // Call service to update category
            var res = await _productSurvice.UpdateProductAsync(productDto);

            // Check if the operation was successful
            if (!res.isSuccess)
            {
                TempData["error"] = "Product is not Updated";
                return View("Error");
            }

            TempData["success"] = "Product Updated successfully";


            return RedirectToAction("Index");
        }




        // Delete
        public async Task<IActionResult> Delete(int prodId)
        {
            // Call service to delete category
            var res = await _productSurvice.DeleteProductyAsync(prodId);

            // Check if the operation was successful
            if (!res.isSuccess)
            {
                TempData["error"] = "Product is not Deleted";
                return View("Error");
            }

            TempData["success"] = "Product Deleted successfully";

            return RedirectToAction("Index");
        }







        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var products = await _productSurvice.GetMyProductsAsync(userId);

            if (!products.isSuccess)
            {
                // Handle the error appropriately (e.g., log it, show a message to the user, etc.)
                return View("Error");
            }

            var res = products.result;

            return View(res);

        }
    }
}
