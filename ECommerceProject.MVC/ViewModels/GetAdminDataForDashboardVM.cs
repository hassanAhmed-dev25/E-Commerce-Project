namespace ECommerceProject.MVC.ViewModels
{
    public class GetAdminDataForDashboardVM
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int PendingWithdrawals { get; set; }
        public int TotalUsers { get; set; }
    }
}
