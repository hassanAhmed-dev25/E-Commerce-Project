using ECommerceProject.Application.DTOs.Admin;

namespace ECommerceProject.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public Task<IEnumerable<GetUserDto>> GetAllWithRolesAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
