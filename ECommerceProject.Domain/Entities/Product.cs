namespace ECommerceProject.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Foreign Keys
        public string? CreatedBy { get; set; }
        public int CategoryId { get; set; }


        // Navigation Properties
        public Category? Category { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }

    }
}
