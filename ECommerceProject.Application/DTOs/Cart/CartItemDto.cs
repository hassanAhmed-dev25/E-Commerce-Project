namespace ECommerceProject.Application.DTOs.Cart
{
    public class CartItemDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
