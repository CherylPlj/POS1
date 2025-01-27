using Microsoft.AspNetCore.Mvc;
using POS1.Models;
using BCrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace POS1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult LoginPage()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginPage(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))  // Compare the entered password with the hashed password
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserFullName", user.FullName);
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid login credentials. Please try again.";
            return View("LoginPage");
        }

        public IActionResult RegisterPage()
        {
            return View(); // Return the view for the register page
        }
    }
}
       
