namespace ECommerceProject.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "The name is required")]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }


        [MaxLength(500)]
        public string Description { get; set; }
    }
}
