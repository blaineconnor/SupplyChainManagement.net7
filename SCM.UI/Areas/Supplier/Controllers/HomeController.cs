using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Supplier.Controllers
{
    [Area("Supplier")]
    public class HomeController : Controller
    {
        [HttpGet("/supplier/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
