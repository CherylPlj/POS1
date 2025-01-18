namespace POS1.Models
{
    public class DashboardViewModel
    {
        public int DailySales { get; set; }
        public int WeeklySales { get; set; }
        public int MonthlySales { get; set; }
        public int YearlySales { get; set; }
        public int TotalSales { get; set; }
        public int CustomerCount { get; set; }

        public List<Product>? TopProducts { get; set; }
        public List<string>? TopCategories { get; set; }  // Change to List<string>
        public List<string>? PaymentMethods { get; set; }
        public List<string>? OrderStatuses { get; set; }
    }
}
