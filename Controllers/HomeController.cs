using PoeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PoeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(productTable.con_string))
                {
                    connection.Open();
                    return Content("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                return Content("Database connection failed: " + ex.Message);
            }
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int userId)
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       

    }
}
