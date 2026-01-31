using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IUserService
    {
        //Task<IEnumerable<GetUserDto>> GetAllAsync();
        //Task<IList<string>> GetUserRolesAsync(string userId);
        Task<IEnumerable<GetUserDto>> GetAllWithRolesAsync();
        Task ToggleBlockAsync(string userId);
    }

}
