namespace ECommerceProject.Application.DTOs.CartItem
{
    public class CreateCartItemDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }

    }
}
