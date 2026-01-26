using ECommerceProject.Application.DTOs.Admin;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        public AdminService(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }



        public async Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync()
        {
            return await _userService.GetAllWithRolesAsync();
        }


    }
}
