using ECommerceProject.Application.DTOs.Cart;
using ECommerceProject.Application.DTOs.Product;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.Domain.Entities;
using ECommerceProject.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ECommerceProject.MVC.Controllers
{
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private readonly IProductSurvice _productService;
        private readonly ICategoryService _categoryService;

        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        public ProductController(IProductSurvice productService, ICategoryService categoryService, ICartService cartService, ICartItemService cartItemService)
        {
            _productService = productService;
            _categoryService = categoryService;

            _cartService = cartService;
            _cartItemService = cartItemService;
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
            // Add User that created this product
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            productDto.CreatedBy = userId;



            // Validate the model
            // if false return the view with the model to show validation errors
            if (!ModelState.IsValid)
            {
                await LoadCategories();

                return View(productDto);
            }

            


            var res = await _productService.CreateProductyAsync(productDto);

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var ResponceProductDto = await _productService.GetProductForUpdateAsync(prodId, userId);


            // Check if this is the owner of this product
            if (!ResponceProductDto.isSuccess)
                return Forbid();


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
            var res = await _productService.UpdateProductAsync(productDto);

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var res = await _productService.DeleteProductyAsync(prodId, userId);

            // Check if this is the owner of this product
            if (!res.isSuccess)
                return Forbid();


            TempData["success"] = "Product Deleted successfully";

            return RedirectToAction("Index");
        }






        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var products = await _productService.GetMyProductsAsync(userId);

            if (!products.isSuccess)
            {
                // Handle the error appropriately (e.g., log it, show a message to the user, etc.)
                return View("Error");
            }

            var res = products.result;

            return View(res);

        }





        // Show All Products
        [AllowAnonymous]
        public async Task<IActionResult> ShowAllProducts(int? catgId)
        {
            var products = catgId == null
                ? await _productService.GetAllProductsAsync()
                : await _productService.GetProductsByCategoryIdAsync(catgId.Value);

            ViewBag.Categories = (await _categoryService.GetAllCategoriesAsync()).result;


            var allProducts = products.result;


            // get its cart
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CartDto cart = null;
            if (!string.IsNullOrEmpty(userId))
                cart = await _cartService.GetOrCreateCartAsync(userId);


            var vm = new List<ProductDetailsVM>();
            foreach (var product in products.result)
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
        [AllowAnonymous]
        public async Task<IActionResult> ViewProduct(int prodId)
        {
            var productResult = await _productService.GetProductByIdAsync(prodId);

            var prod = productResult.result;

            // get its cart
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CartDto cart = null;
            if (!string.IsNullOrEmpty(userId))
                cart = await _cartService.GetOrCreateCartAsync(userId);

            var vm = new ProductDetailsVM
            {
                Product = prod,
                IsInCart = cart != null && await _cartItemService.IsProductInCartAsync(cart.Id, prodId)
            };

            return View(vm);
        }



    }
}
