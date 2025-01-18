using System.ComponentModel.DataAnnotations;

namespace POS1.Models
{
    public class DashboardMetricsViewModel
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
        public List<Order> Orders { get; internal set; }
    }
        //    // Sales Metrics
        //    [Display(Name = "Daily Sales Count")]
        //    public int DailySales { get; set; }

        //    [Display(Name = "Weekly Sales Count")]
        //    public int WeeklySales { get; set; }

        //    [Display(Name = "Monthly Sales Count")]
        //    public int MonthlySales { get; set; }

        //    [Display(Name = "Yearly Sales Count")]
        //    public int YearlySales { get; set; }

        //    [Display(Name = "Total Sales Amount")]
        //    public int TotalSales { get; set; }

        //    // Top Products
        //    [Display(Name = "Top Selling Products")]
        //    public List<SalesData>? TopProducts { get; set; }

        //    // Top Categories
        //    [Display(Name = "Top Selling Categories")]
        //    public List<Product>? TopCategories { get; set; }

        //    // Payment Methods
        //    [Display(Name = "Most Used Payment Methods")]
        //    public List<Payment>? PaymentMethods { get; set; }

        //    // Order Statuses
        //    [Display(Name = "Orders by Status")]
        //    public List<SalesData>? OrderStatuses { get; set; }
        //}

        // Example for referenced types (if not already defined)
        //public class SalesData
        //{
        //    public string Name { get; set; } // e.g., Product Name, Status Name
        //    public int Count { get; set; }  // e.g., Total Sales Count
        //}

        //public class Product
        //{
        //    public string Category { get; set; } // Category name
        //    public int Count { get; set; }      // Number of products sold
        //}

        //public class Payment
        //{
        //    public string Method { get; set; } // Payment method (e.g., Card, COD, etc.)
        //    public int UsageCount { get; set; } // Count of method usage
        //}
    }
