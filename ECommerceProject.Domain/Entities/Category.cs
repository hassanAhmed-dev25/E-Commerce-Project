namespace ECommerceProject.Domain.Entities
{
    public class Category
    {
        public int Id { get; set;}
        public required string Name { get; set;}
        public bool IsActive { get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



        // Navigation Properties
        public ICollection<Product>? Products { get; set; }

    }
}
