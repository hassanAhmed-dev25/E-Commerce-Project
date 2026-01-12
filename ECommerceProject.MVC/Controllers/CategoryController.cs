using ECommerceProject.Application.DTOs;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.MVC.ViewModels;
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
        public async Task<IActionResult> Create(CreateCategoryVM categoryVM)
        {

            // Mapp ViewModel to DTO
            var createCategoryDto = new CreateCategoryDto
            {
                Name = categoryVM.Name,
                Description = categoryVM.Description
            };

            var res = await _categoryService.CreateCategoryAsync(createCategoryDto);

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
            var categoryDto = await _categoryService.GetCategoryByIdAsync(catgId);

            // Check if the operation was successful
            if (!categoryDto.isSuccess)
            {
                return View("Error");
            }


            // Extract the category data
            var category = categoryDto.result;

            // Mapp DTO to ViewModel
            var updateCategoryVM = new UpdateCategoryVM
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return View(updateCategoryVM);


        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM categoryVM)
        {
            // Mapp ViewModel to DTO
            var updateCategoryDto = new UpdateCategoryDto
            {
                Id =  categoryVM.Id,
                Name = categoryVM.Name,
                Description = categoryVM.Description
            };

            // Call service to update category
            var res = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

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

            // Mapp DTOs to ViewModels
            var viewModelList = res.Select(c => new GetCategoryVM
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ProductCount = c.ProductCount,

            }).ToList();

            return View(viewModelList);
        }

    }
}
