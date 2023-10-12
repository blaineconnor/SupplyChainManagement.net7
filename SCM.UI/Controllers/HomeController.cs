using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
