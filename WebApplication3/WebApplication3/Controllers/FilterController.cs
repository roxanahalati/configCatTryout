using Microsoft.AspNetCore.Mvc;
using WebApplication3.DataAbstractionLayer;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View("FilterUsers");
        }

        public string GetUsersByRole()
        {

            string role = Request.Query["role"];

            Console.WriteLine(role);
            List<User> slist;
            DAL dal = new DAL();
            if (role == "")
            {
                slist = dal.GetAllUsers();
            }
            else
            {
                slist = dal.GetUsersByRole(role);
            }
            ViewData["usersList"] = slist;

            string result = "<table><thead><th>Name</th><th>Username</th><th>Age</th><th>Role</th><th>Email</th></thead>";

            foreach (User user in slist)
            {
                result += "</td><td>" + user.name + "</td><td>" + user.username + "</td><td>" + user.role + "</td><td>" + user.age + "</td><td>" + user.email + "</td></tr>";
            }

            result += "</table>";
            return result;
        }
    }
}
