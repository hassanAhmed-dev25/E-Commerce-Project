using ECommerceProject.Application.DTOs.Account;

namespace ECommerceProject.Infrastructure.Services
{
    internal class ExternalAuthService : IExternalAuthService
    {
        public Task<ExternalLoginResultDto> ExternalLoginAsync(ExternalLoginDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
