using ECommerceProject.Application.DTOs.Admin;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        public IUserService _userService;
        public AdminService(IUserService userService)
        {
            _userService = userService;
        }



        public async Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync()
        {
            return await _userService.GetAllWithRolesAsync();
        }


    }
}
