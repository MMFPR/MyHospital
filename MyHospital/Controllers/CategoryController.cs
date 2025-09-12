using Microsoft.AspNetCore.Mvc;

namespace MyHospital.Controllers
{
    public class CategoryController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
    }
}
