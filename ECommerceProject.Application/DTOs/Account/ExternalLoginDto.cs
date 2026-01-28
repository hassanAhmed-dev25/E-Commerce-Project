namespace ECommerceProject.Application.DTOs.Account
{
    public class ExternalLoginDto
    {
        [Required]
        public string Provider { get; set; } // Google, Microsoft, Facebook
        [Required]
        public string ProviderKey { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }

}
