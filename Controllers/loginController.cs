using Microsoft.AspNetCore.Mvc;
using PoeProject.Models;
namespace PoeProject.Controllers
{
    public class loginController : Controller
    {
        private readonly Logincntrl login;

        public loginController()
        {
            login = new Logincntrl();
        }

        [HttpPost]
        public ActionResult Privacy(string email, string userName)
        {
            var loginModel = new Logincntrl();
            int userId = loginModel.SelectUser(email, userName);
            if (userId != -1)
            {
                return RedirectToAction("Index", "Home", new { userId = userId });
            }
            else
            {
                return View("LoginFailed");
            }
        }
    }
}
