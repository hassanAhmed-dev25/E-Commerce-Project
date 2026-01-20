using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Order;

namespace ECommerceProject.MVC.ViewModels
{
    public class CheckoutVM
    {
        public IEnumerable<CartItemDto> CartItems { get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }

       // public IEnumerable<int> SelectedCartItemIds { get; set; }
    }
}
