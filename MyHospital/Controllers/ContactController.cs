using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
