using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
