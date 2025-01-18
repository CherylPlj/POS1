using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using POS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace POS1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // Combined constructor accepting both ILogger and ApplicationDbContext
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Home page logic
        public IActionResult Index()
        {
            var model = new DashboardMetricsViewModel
            {
                DailySales = _context.Orders.Count(o => o.CreatedAt >= DateTime.Today),
                WeeklySales = _context.Orders.Count(o => o.CreatedAt >= DateTime.Today.AddDays(-7)),
                MonthlySales = _context.Orders.Count(o => o.CreatedAt >= DateTime.Today.AddMonths(-1)),
                YearlySales = _context.Orders.Count(o => o.CreatedAt >= DateTime.Today.AddYears(-1)),
                TotalSales = _context.Orders.Count(o => o.CreatedAt != null),
                TopProducts = _context.Products.OrderByDescending(p => p.CurrentStock).Take(5).ToList(),
                TopCategories = _context.Products
                                .GroupBy(p => p.Category)
                                .OrderByDescending(g => g.Count())
                                .Take(5)
                                .Select(g => g.Key)  // Select the category names (strings)
                                .ToList(),
                PaymentMethods = _context.Payments
                                .GroupBy(p => p.PaymentType)
                                .Select(g => g.Key)
                                .ToList(),
                OrderStatuses = _context.Orders
                                .Select(o => o.OrderStatus)
                                .Distinct()
                                .ToList()
            };

            return View(model);
        }

        // Mock sales data
        private List<SalesData> GetSalesData()
        {
            return new List<SalesData>
            {
                new SalesData { Date = DateTime.Now, ProductName = "Product A", Category = "Category 1", Amount = 100 }
            };
        }

        // Mock order data
        private List<OrderData> GetOrderData()
        {
            return new List<OrderData>
            {
                new OrderData { OrderDate = DateTime.Now, PaymentMethod = "Card", Status = "Processed" }
            };
        }



        // Logout action
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // Clear session or authentication cookies
            HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage", "Login");
        }

        // Error handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
