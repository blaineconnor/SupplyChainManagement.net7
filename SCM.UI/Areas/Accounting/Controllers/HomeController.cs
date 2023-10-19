using Microsoft.AspNetCore.Mvc;

namespace SCM.UI.Areas.Accounting.Controllers
{
    [Area("Accounting")]
    public class HomeController : Controller
    {
        [HttpGet("accounting/index")]
        public IActionResult AccountingIndex()
        {
            return View();
        }
    }
}
