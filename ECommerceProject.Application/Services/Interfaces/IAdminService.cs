using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync();
    }
}
