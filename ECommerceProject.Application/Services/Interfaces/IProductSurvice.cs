using ECommerceProject.Application.DTOs.Product;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IProductSurvice
    {
        Task<Response<bool>> CreateProductyAsync(CreateProductDto productDto);
        Task<Response<bool>> UpdateProductAsync(UpdateProductDto productDto);
        Task<Response<bool>> DeleteProductyAsync(int productId, string userId);
        Task<Response<GetProductDto>> GetProductByIdAsync(int id);
        Task<Response<IEnumerable<GetProductDto>>> GetProductsByCategoryIdAsync(int catgId);

        Task<Response<IEnumerable<GetProductDto>>> GetAllProductsAsync();
        Task<Response<IEnumerable<GetProductDto>>> GetMyProductsAsync(string userId);


        Task<Response<GetProductDto>> GetProductForUpdateAsync(int productId, string userId);

    }
}
