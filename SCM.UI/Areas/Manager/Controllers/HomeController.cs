using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        [HttpGet("/manager/index")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
