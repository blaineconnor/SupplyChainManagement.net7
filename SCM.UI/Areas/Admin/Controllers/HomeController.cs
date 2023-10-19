using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [HttpGet("/admin/index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
