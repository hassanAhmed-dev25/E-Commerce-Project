namespace ECommerceProject.Application.DTOs.Product
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }


        [Required(ErrorMessage = "The Price is required")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "The Stock Quantity is required")]
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }


        [MaxLength(500)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }


        [Required(ErrorMessage = "The Category is required")]
        public int CategoryId { get; set; }
    }
}
