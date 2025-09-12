using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
