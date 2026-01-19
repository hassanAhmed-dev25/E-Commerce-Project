using ECommerceProject.Application.DTOs.CartItem;

namespace ECommerceProject.Application.DTOs.Order
{
    public class PlaceOrderDto
    {
        public List<CartItemDto> CartItemsDto {  get; set; }
        public ShippingAddressDto ShippingAddressDto { get; set; }

        public string PaymentMethod { get; set; }
        public string UserId { get; set; }
    }
}
