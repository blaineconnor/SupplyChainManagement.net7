using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController : Controller
    {
        [HttpGet("/employee/index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
