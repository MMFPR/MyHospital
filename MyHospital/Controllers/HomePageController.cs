using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
