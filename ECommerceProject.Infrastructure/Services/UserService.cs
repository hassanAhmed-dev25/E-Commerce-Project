using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IOrderService _orderService;
        private readonly IProductSurvice _productService;

        public UserService(UserManager<ApplicationUser> userManager, IOrderService orderService, IProductSurvice productService)
        {
            _userManager = userManager;

            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IEnumerable<GetUserDto>> GetAllWithRolesAsync()
        {
            
            var users = _userManager.Users.ToList();

            //if(!users.Any())
            //    throw new ArgumentException("There is no Users");

            var res = new List<GetUserDto>();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);

                res.Add(new GetUserDto
                {
                    Email = user.Email,
                    Role = role.ElementAt(0),
                    IsBlocked = false, // not supported yet

                    OrdersCount = await _orderService.GetTotalOrdersAsync(user.Id),
                    ProductsCount = await _productService.GetTotalProductsAsync(user.Id)
                });


            }
            
            return res;
        }

    }
}
