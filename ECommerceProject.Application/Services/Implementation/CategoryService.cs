namespace ECommerceProject.Application.Services.Implementation
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Response<bool>> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            try
            {

                // Validation
                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return new Response<bool>(false, "Category name is required", false);
                }

                var exists = await _unitOfWork.Categories
                                                      .GetAsync(c => c.Name == categoryDto.Name);

                if (exists != null)
                {
                    return new Response<bool>(false, "Category already exists", false);
                }



                // Mapp DTO to Entity (Later i will add Auto Mapper)
                var newCategory = new Category
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description,
                };


                // Add to Database
                await _unitOfWork.Categories.AddAsync(newCategory);


                // Saving database
                await _unitOfWork.SaveChangesAsync();


                // Return Response
                return new Response<bool> (true, "Category created successfully", true);

            }
            catch (Exception ex)
            {
                return new Response<bool> (false, ex.Message, false);
            }

        }
        public async Task<Response<bool>> UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return new Response<bool>(false, "Category name is required", false);
                }


                // Get existing category
                var existingCategory = await _unitOfWork.Categories
                                                               .GetAsync(c => c.Id == categoryDto.Id);

                if (existingCategory == null)
                {
                    return new Response<bool>(false, "Category not found", false);
                }



                // Check is name is uniqu
                //var exists = await _unitOfWork.Categories
                //                                      .GetAsync(c => c.Name == categoryDto.Name);

                //if (exists != null)
                //{
                //    return new Response<bool>(false, "Category already exists", false);
                //}



                // Update Entity
                existingCategory.Name = categoryDto.Name;
                existingCategory.Description = categoryDto.Description;


                await _unitOfWork.Categories.UpdateAsync(existingCategory);


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
        public async Task<Response<bool>> DeleteCategoryAsync(int id)
        {
            try
            {

                // Check is exist
                var existingCategory = await _unitOfWork.Categories
                                                     .GetAsync(c => c.Id == id);

                if(existingCategory == null)
                {
                    return new Response<bool>(false, "Category not found", false);
                }


                // Delete it
                await _unitOfWork.Categories.RemoveAsync(id);


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



        public async Task<Response<IEnumerable<GetCategoryDto>>> GetAllCategoriesAsync()
        {
            try
            {
                // Getting the category
                var category = await _unitOfWork.Categories
                                                                  .GetAllAsync();

                // Check is null or not
                if (category == null)
                {
                    return new Response<IEnumerable<GetCategoryDto>>(null, "Categories not found", false);
                }


                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var categoryResult = new List<GetCategoryDto>();
                foreach(var catg in category)
                {
                    categoryResult.Add(new GetCategoryDto
                    {
                        Id = catg.Id,
                        Name = catg.Name,
                        Description = catg.Description,
                        ProductCount = catg.Products != null ? catg.Products.Count : 0
                    });
                }
                


                return new Response<IEnumerable<GetCategoryDto>>(categoryResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GetCategoryDto>>(null, ex.Message, false);
            }
        }

        public async Task<Response<GetCategoryDto>> GetCategoryByIdAsync(int id)
        {
            try
            {
                // Getting the category
                var category = await _unitOfWork.Categories
                                                             .GetAsync(c => c.Id == id);

                // Check is null or not
                if(category == null)
                {
                    return new Response<GetCategoryDto>(null, "Category not found", false);
                }

                // Mapp Entity to DTO (Later i will add Auto Mapper)
                var categoryResult = new GetCategoryDto 
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };


                return new Response<GetCategoryDto>(categoryResult, null, true);

            }
            catch (Exception ex)
            {
                return new Response<GetCategoryDto>(null, ex.Message, false);
            }
        }

        
    }
}
