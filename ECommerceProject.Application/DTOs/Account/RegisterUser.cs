namespace ECommerceProject.Application.DTOs.Account
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "First name is required")]
        [MinLength(4, ErrorMessage = "First name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "First name must not exceed 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(4, ErrorMessage = "Last name must be at least 2 characters")]
        [MaxLength(100, ErrorMessage = "Last name must not exceed 100 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [MinLength(4, ErrorMessage = "User name must be at least 4 characters")]
        [MaxLength(100, ErrorMessage = "User name must not exceed 100 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        [MaxLength(50, ErrorMessage = "Password must not exceed 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
