using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Purchasing.Controllers
{
    [Area("Purchasing")]
    public class HomeController : Controller
    {
        [HttpGet("/purchasing/index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
