using Microsoft.AspNetCore.Mvc;

namespace CoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "AddressBook");
        }
    }
}