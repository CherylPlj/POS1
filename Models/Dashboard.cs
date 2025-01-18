using System.ComponentModel.DataAnnotations;

namespace POS1.Models
{
    public class SalesData
    {
        public DateTime Date { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderData
    {
        public DateTime OrderDate { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }
    }
}