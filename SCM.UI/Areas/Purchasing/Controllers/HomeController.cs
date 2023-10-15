using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Area("Purchasing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
