using majed_asp_mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    [SessionAuthorize]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
