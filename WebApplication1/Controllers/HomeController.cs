using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            // Validate user credentials
            if (user.Username == "admin" && user.Password == "password")
            {
                // Login successful, store user information in TempData (one-time storage)
                TempData["LoggedInUser"] = user.Username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Login failed
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            // Validate user data and register user in your data source (e.g., database)
            // For simplicity, this example skips actual registration logic
            if (ModelState.IsValid) // Assuming basic validation is done in the model
            {
                return RedirectToAction("Login"); // Redirect to login page after registration
            }
            else
            {
                // Registration failed, display validation errors
                return View(user);
            }
        }
    }
}
