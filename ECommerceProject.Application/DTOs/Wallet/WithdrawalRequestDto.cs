namespace ECommerceProject.Application.DTOs.Wallet
{
    public class WithdrawalRequestDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public WithdrawalStatus WithdrawalStatus { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
