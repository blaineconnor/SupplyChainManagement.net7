using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
