namespace ECommerceProject.Application.Common
{
    public record Response<T>(T? result, string? errorMessege , bool isSuccess);

}
