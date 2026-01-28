using ECommerceProject.Application.DTOs.Account;

namespace ECommerceProject.Application.Services.Interfaces
{
    public interface IExternalAuthService
    {
        Task<ExternalLoginResultDto> ExternalLoginAsync(ExternalLoginDto dto);

    }
}
