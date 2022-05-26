using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.DataAbstractionLayer;
namespace WebApplication3.Controllers
{
    public class AddUser : Controller
    {
        public IActionResult Index()
        {
            return View("AddNewUser");
        }

        public ActionResult SaveUser()
        {
            User user = new User();


            user.name = Request.Query["name"];
            user.username = Request.Query["username"];
            user.age = Int32.Parse(Request.Query["age"]);
            user.role = Request.Query["role"];
            user.email = Request.Query["email"];

            DAL dal = new DAL();
            dal.SaveUser(user); ;
            return RedirectToAction("Index", "Main");
        }
    }
}
