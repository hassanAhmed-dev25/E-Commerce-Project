namespace ECommerceProject.Application.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }


        public string? CreatedBy { get; set; }

        public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
    }
}
