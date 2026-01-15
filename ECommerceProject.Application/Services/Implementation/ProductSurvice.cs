using ECommerceProject.Application.DTOs.Product;
using ECommerceProject.Application.Helper;
namespace ECommerceProject.Application.Services.Implementation
{
    public class ProductSurvice : IProductSurvice
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductSurvice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<bool>> CreateProductyAsync(CreateProductDto productDto)
        {
            try
            {

                // Validation
                var exists = await _unitOfWork.Products
                                                      .GetAsync(c => c.Name == productDto.Name);

                if (exists != null)
                {
                    return new Response<bool>(false, "Product already exists", false);
                }


                // Upload Image to server
                var imgUrl = Upload.UploadFile("Files", productDto.Image);



                // Mapp DTO to Entity (Later i will add Auto Mapper)
                var newProduct = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    StockQuantity = productDto.StockQuantity,
                    IsActive = productDto.IsActive,
                    Description = productDto.Description,
                    ImageUrl = imgUrl,
                    CreatedBy = productDto.CreatedBy,
                    CategoryId = productDto.CategoryId,
                };


                // Add to Database
                await _unitOfWork.Products.AddAsync(newProduct);


                // Saving database
                await _unitOfWork.SaveChangesAsync();


                // Return Response
                return new Response<bool>(true, "Category created successfully", true);

            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        public async Task<Response<bool>> UpdateProductAsync(UpdateProductDto productDto)
        {
            try
            {
                // Validation

                // Get existing product
                var existingProduct = await _unitOfWork.Products
                                                               .GetAsync(c => c.Id == productDto.Id);

                if (existingProduct == null)
                {
                    return new Response<bool>(false, "Category not found", false);
                }


                // Remove Old Image from server
                if (productDto.Image != null)
                {
                    Upload.RemoveFile("Files", existingProduct.ImageUrl);
                }

                // Upload Updated Image to server
                var imgUrl = Upload.UploadFile("Files", productDto.Image);



                // Update Entity
                existingProduct.Name = productDto.Name;
                existingProduct.Price = productDto.Price;
                existingProduct.StockQuantity = productDto.StockQuantity;
                existingProduct.IsActive = productDto.IsActive;
                existingProduct.Description = productDto.Description;
                existingProduct.ImageUrl = imgUrl;



                await _unitOfWork.Products.UpdateAsync(existingProduct);


                // Saving database
                await _unitOfWork.SaveChangesAsync();


                // Return Response
                return new Response<bool>(true, "Category updated successfully", true);

            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }

        public async Task<Response<bool>> DeleteProductyAsync(int id)
        {
            try
            {

                // Check is exist
                var existingProduct = await _unitOfWork.Products
                                                     .GetAsync(c => c.Id == id);

                if (existingProduct == null)
                {
                    return new Response<bool>(false, "Category not found", false);
                }


                // Delete it
                await _unitOfWork.Products.RemoveAsync(id);


                // Saving database
                await _unitOfWork.SaveChangesAsync();



                // Return Response
                return new Response<bool>(true, "Category deleted successfully", true);

            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, false);
            }
        }


        public async Task<Response<IEnumerable<GetProductDto>>> GetAllProductsAsync()
        {
            try
            {
                // Getting the Products
                var products = await _unitOfWork.Products
                                                                  .GetAllWithAsync(null, p => p.Category);

                // Check is null or not
                if (products == null)
                {
                    return new Response<IEnumerable<GetProductDto>>(null, "Categories not found", false);
                }


                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var productsResult = new List<GetProductDto>();
                foreach (var catg in products)
                {
                    productsResult.Add(new GetProductDto
                    {
                        Id = catg.Id,
                        Name = catg.Name,
                        Price = catg.Price,
                        StockQuantity = catg.StockQuantity,
                        IsActive = catg.IsActive,
                        Description = catg.Description,
                        ImageUrl = catg.ImageUrl,
                        CreatedAt = catg.CreatedAt,

                        CategoryName = catg.Category.Name
                    });
                }



                return new Response<IEnumerable<GetProductDto>>(productsResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GetProductDto>>(null, ex.Message, false);
            }
        }

        public async Task<Response<GetProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                // Getting the product
                var product = await _unitOfWork.Products
                                                             .GetAsync(p => p.Id == id);

                // Check is null or not
                if (product == null)
                {
                    return new Response<GetProductDto>(null, "Products not found", false);
                }

                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var productResult = new GetProductDto
                {
                    Id = product.Id,
                    Name= product.Name,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    IsActive = product.IsActive,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    CreatedAt = product.CreatedAt,
                    CategoryId = product.CategoryId,
                };


                return new Response<GetProductDto>(productResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<GetProductDto>(null, ex.Message, false);
            }
        }

        public async Task<Response<IEnumerable<GetProductDto>>> GetMyProductsAsync(string userId)
        {
            try
            {
                // Getting the Products
                var products = await _unitOfWork.Products
                                                                  .GetAllWithAsync(p => p.CreatedBy == userId, p => p.Category);

                // Check is null or not
                if (products == null)
                {
                    return new Response<IEnumerable<GetProductDto>>(null, "Products not found", false);
                }


                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var productsResult = new List<GetProductDto>();
                foreach (var catg in products)
                {
                    productsResult.Add(new GetProductDto
                    {
                        Id = catg.Id,
                        Name = catg.Name,
                        Price = catg.Price,
                        StockQuantity = catg.StockQuantity,
                        IsActive = catg.IsActive,
                        Description = catg.Description,
                        ImageUrl = catg.ImageUrl,
                        CreatedAt = catg.CreatedAt,

                        CategoryName = catg.Category.Name
                    });
                }



                return new Response<IEnumerable<GetProductDto>>(productsResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GetProductDto>>(null, ex.Message, false);
            }
        }

        public async Task<Response<GetProductDto>> GetProductForUpdateAsync(int productId, string userId)
        {
            try
            {
                // Getting the product
                var product = await _unitOfWork.Products
                                                             .GetAsync(p => p.Id == productId && p.CreatedBy == userId);

                // Check is null or not
                if (product == null)
                {
                    return new Response<GetProductDto>(null, "Access denied", false);
                }

                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var productResult = new GetProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity,
                    IsActive = product.IsActive,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    CreatedAt = product.CreatedAt,
                    CategoryId = product.CategoryId,
                };


                return new Response<GetProductDto>(productResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<GetProductDto>(null, ex.Message, false);
            }
        }
    }
}
