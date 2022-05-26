using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;
using ConfigCat.Client;
namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var client = new ConfigCatClient("8z7aCC-DZEaPwUCnitpksg/TbJ8oi7sMUynCb8MxtTUDw");

            var prettyViewEnabled = client.GetValue("prettyViewEnabled", false);

            Console.WriteLine("prettyViewEnabled's value from ConfigCat: " + prettyViewEnabled);
            if (prettyViewEnabled)
            {
                return View("WomanMainView");
            }
            else
            {

                return View("ManMainView");
              }
        }
    }
}