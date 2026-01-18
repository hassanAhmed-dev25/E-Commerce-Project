namespace ECommerceProject.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        // Foreign Keys
        public string UserId { get; set; }


        // Navigation Properties
        public ICollection<CartItem>? CartItems { get; set; }

    }
}
