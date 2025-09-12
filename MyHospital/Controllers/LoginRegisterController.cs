using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class LoginRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
