using Microsoft.AspNetCore.Mvc;

namespace Jane_Fast_Lane.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
