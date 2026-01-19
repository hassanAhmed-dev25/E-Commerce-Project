namespace ECommerceProject.Application.DTOs.Order
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<GetOrderItemDto> Items { get; set; }
        public GetShippingAddressDto ShippingAddress { get; set; }
    }

}
