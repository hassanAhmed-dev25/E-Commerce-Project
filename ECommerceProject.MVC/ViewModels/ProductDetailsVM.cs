using ECommerceProject.Application.DTOs.CartItem;
using ECommerceProject.Application.DTOs.Product;

namespace ECommerceProject.MVC.ViewModels
{
    public class ProductDetailsVM
    {
        public GetProductDto Product { get; set; }
        public bool IsInCart { get; set; }
    }
}
