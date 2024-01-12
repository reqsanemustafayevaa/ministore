using Microsoft.AspNetCore.Mvc;

namespace ministore.mvc.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
