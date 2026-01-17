namespace ECommerceProject.Application.DTOs.CartItem
{
    public class CartItemDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
