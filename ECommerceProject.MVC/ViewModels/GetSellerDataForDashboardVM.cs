namespace ECommerceProject.MVC.ViewModels
{
    public class GetSellerDataForDashboardVM
    {
        public decimal TotalSales { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal PendingWithdrawals { get; set; }
        public int TotalOrders { get; set; }
        
    }
}
