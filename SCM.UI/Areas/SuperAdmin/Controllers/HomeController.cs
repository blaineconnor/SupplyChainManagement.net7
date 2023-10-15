using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
