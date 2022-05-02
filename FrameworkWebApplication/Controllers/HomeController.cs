using System.Web.Mvc;

namespace FrameworkWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "AddressBook");
        }
    }
}