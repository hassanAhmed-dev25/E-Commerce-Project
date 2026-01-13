using ECommerceProject.Application.DTOs.Category;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<bool>> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<Response<bool>> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task<Response<bool>> DeleteCategoryAsync(int id);

        Task<Response<GetCategoryDto>> GetCategoryByIdAsync(int id);
        Task<Response<IEnumerable<GetCategoryDto>>> GetAllCategoriesAsync();

    }
}
