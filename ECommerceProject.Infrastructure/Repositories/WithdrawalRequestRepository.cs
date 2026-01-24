namespace ECommerceProject.Infrastructure.Repositories
{
    public class WithdrawalRequestRepository :Repository<WithdrawalRequest>, IWithdrawalRequestRepository
    {
        public WithdrawalRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
