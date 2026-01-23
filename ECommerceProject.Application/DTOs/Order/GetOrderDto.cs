namespace ECommerceProject.Application.DTOs.Order
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }


        public string OrderStatusName { get; set; }
        public string PaymentStatusName { get; set; }


        public List<GetOrderItemDto> Items { get; set; }
        public GetShippingAddressDto ShippingAddress { get; set; }
    }

}
