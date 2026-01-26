using ECommerceProject.Application.DTOs.Wallet;

namespace ECommerceProject.Application.DTOs.Admin
{
    public class GetManageWithdrawalsDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestedAt { get; set; }
        public WithdrawalStatus WithdrawalStatus { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }

    }
}
