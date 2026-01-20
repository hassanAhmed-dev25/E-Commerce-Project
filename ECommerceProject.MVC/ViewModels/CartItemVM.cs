using ECommerceProject.Application.DTOs.CartItem;

namespace ECommerceProject.MVC.ViewModels
{
    public class CartItemVM
    {
        public CartItemDto Items { get; set; }
        public int MaxQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
