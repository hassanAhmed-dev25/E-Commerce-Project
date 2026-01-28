namespace ECommerceProject.Application.DTOs.Account
{
    public class ExternalLoginResultDto
    {
        public bool IsSuccess { get; set; } 
        public bool IsNewUser { get; set; }
        public bool IsHaveRole { get; set; }

        public string Message { get; set; }
    }

}
