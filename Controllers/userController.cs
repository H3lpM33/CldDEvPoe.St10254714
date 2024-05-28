using Microsoft.AspNetCore.Mvc;
using PoeProject.Models;

namespace PoeProject.Controllers
{
    public class userController : Controller
    {
        public userTable usrtbl = new userTable();



        [HttpPost]
        public ActionResult About(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("about", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(usrtbl);
        }
    }
}
