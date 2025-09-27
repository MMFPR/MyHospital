using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
