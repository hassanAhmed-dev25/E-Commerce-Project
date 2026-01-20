using ECommerceProject.Application.DTOs.Order;

namespace ECommerceProject.MVC.ViewModels
{
    public class PlaceOrderVM
    {
        public List<int> SelectedCartItemIds { get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
    }
}
