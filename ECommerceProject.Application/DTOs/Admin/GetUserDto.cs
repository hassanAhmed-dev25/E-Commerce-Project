namespace ECommerceProject.Application.DTOs.Admin
{
    public class GetUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsBlocked { get; set; }
        public int OrdersCount { get; set; }
        public int ProductsCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
