using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
