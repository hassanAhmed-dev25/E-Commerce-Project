using ECommerceProject.Application.DTOs.Admin;
using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<GetUserDto>> GetAllUsersWithRolesAsync();
        Task<IEnumerable<WithdrawalRequestDto>> GetAllWithdrawalsAsync();
    }
}
