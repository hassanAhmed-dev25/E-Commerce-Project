using ECommerceProject.Application.DTOs;
using ECommerceProject.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            // Validate the model
            // if false return the view with the model to show validation errors
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            var res = await _categoryService.CreateCategoryAsync(categoryDto);

            if (!res.isSuccess)
            {
                return View("Error");
            }


            return RedirectToAction("Index");
        }




        // Update
        [HttpGet]
        public async Task<IActionResult> Update(int catgId)
        {
            // Get category by id
            var ResponceCategoryDto = await _categoryService.GetCategoryByIdAsync(catgId);

            // Check if the operation was successful
            if (!ResponceCategoryDto.isSuccess)
            {
                return View("Error");
            }


            // Extract the category data
            var category = ResponceCategoryDto.result;

            //// Mapp GetDTO to UpdateDTO
            var updateCategoryDto = new UpdateCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(updateCategoryDto);


        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            // Validate the model
            // if false return the view with the model to show validation errors
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            // Call service to update category
            var res = await _categoryService.UpdateCategoryAsync(categoryDto);

            // Check if the operation was successful
            if (!res.isSuccess)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }





        // Delete
        public async Task<IActionResult> Delete(int catgId)
        {
            // Call service to delete category
            var res = await _categoryService.DeleteCategoryAsync(catgId);

            // Check if the operation was successful
            if (!res.isSuccess)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }





        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            if(!categories.isSuccess)
            {
                // Handle the error appropriately (e.g., log it, show a message to the user, etc.)
                return View("Error");
            }

            var res = categories.result;

            return View(res);
        }

    }
}
