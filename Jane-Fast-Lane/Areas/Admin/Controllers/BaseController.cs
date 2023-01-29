using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jane_Fast_Lane.Areas.Admin.Controllers
{
    [Authorize(Roles = ("Administrator"))]
    [Area("Admin")]
    public class BaseController : Controller
    {
    }
}
