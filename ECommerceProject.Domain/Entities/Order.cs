using ECommerceProject.Domain.Enums;

namespace ECommerceProject.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }   
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



        // Foreign Keys
        public string UserId { get; set; }


        // Navigation Properties
        public ICollection<OrderItem>? OrderItems { get; set; }


    }
}
