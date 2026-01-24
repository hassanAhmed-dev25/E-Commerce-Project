namespace ECommerceProject.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
    }
}
