using ECommerceProject.Domain.Enums;

namespace ECommerceProject.Domain.Entities
{
    public class WithdrawalRequest
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public WithdrawalStatus WithdrawalStatus { get; set; } = WithdrawalStatus.Pending;

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime ApprovedAt { get; set; }
        public DateTime CompletedAt { get; set; }



        // Foreign Keys
        public int SellerId { get; set; }
    }
}
