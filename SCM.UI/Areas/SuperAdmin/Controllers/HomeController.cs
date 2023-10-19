using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class HomeController : Controller
    {
        [HttpGet("/superadmin/index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
